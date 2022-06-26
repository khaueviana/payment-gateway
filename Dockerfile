#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0.6-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0.301-focal AS build
WORKDIR /source

COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
COPY PaymentGateway.sln PaymentGateway.sln

RUN curl https://api.nuget.org/v3/index.json -v

RUN dotnet restore PaymentGateway.sln

WORKDIR /source

RUN dotnet build PaymentGateway.sln -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Presentation.csproj -c Release -o /app/publish

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT dotnet Presentation.dll