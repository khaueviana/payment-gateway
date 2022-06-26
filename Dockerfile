FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY src/*/*.csproj ./

RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

COPY PaymentGateway.sln PaymentGateway.sln

RUN dotnet restore PaymentGateway.sln

COPY . .

RUN dotnet build PaymentGateway.sln -c Release -o /app/build

FROM build AS publish

RUN dotnet publish src/Presentation/Presentation.csproj -c Release -o /app/publish

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:9882

ENTRYPOINT dotnet Presentation.dll