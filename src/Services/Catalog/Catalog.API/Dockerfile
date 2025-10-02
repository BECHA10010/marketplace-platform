FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Catalog.API.csproj", "./"]
COPY ["../Catalog.Application/Catalog.Application.csproj", "../Catalog.Application/"]
COPY ["../Catalog.Domain/Catalog.Domain.csproj", "../Catalog.Domain/"]
COPY ["../Catalog.Infrastructure/Catalog.Infrastructure.csproj", "../Catalog.Infrastructure/"]

RUN dotnet restore "Catalog.API.csproj"

COPY . .

RUN dotnet build "Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Catalog.API.dll"]