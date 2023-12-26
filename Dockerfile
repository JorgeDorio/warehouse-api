# Base image with .NET 8 runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

EXPOSE 8080

# Create app directory
WORKDIR /app

# Copy .csproj and restore NuGet packages as a separate layer
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App
COPY ["Warehouse.csproj", "."]
RUN dotnet restore "Warehouse.csproj"

# Copy remaining project files and build
COPY . .
RUN dotnet build "Warehouse.csproj" -c Release -o /app/build

# Final stage with runtime-only image
FROM base AS final
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "Warehouse.dll"]
