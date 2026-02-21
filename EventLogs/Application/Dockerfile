# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy all .csproj files first (this optimizes Docker layer caching)
COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Domain/Domain.csproj", "Domain/"]

# Restore dependencies
RUN dotnet restore "WebApplication1/WebApplication1.csproj"

# Copy the rest of the code and build
COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build

# 2. Publish Stage
FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish

# 3. Final Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]