# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

# SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# Copy cjproj files
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

# Copy solution
COPY PaymentGateway.sln PaymentGateway.sln

# Restore solution
RUN dotnet restore PaymentGateway.sln

# Copy files
COPY . .

# Build project
RUN dotnet build PaymentGateway.sln -c Release -o /app/build

# Publish project
FROM build AS publish
RUN dotnet publish src/Presentation/Presentation.csproj -c Release -o /app/publish

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

# Set ASP.NET Port
ENV ASPNETCORE_URLS=http://+:9882

ENTRYPOINT dotnet Presentation.dll