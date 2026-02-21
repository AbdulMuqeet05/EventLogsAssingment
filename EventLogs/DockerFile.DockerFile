
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["EventStore/EventStore.csproj", "EventStore/"]


RUN dotnet restore "WebApplication1/WebApplication1.csproj"

COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]