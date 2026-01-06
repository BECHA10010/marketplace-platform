FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["src/Services/Basket/Basket.API/Basket.API.csproj", "src/Services/Basket/Basket.API/"]
COPY ["src/Common/Common.Kernel/Common.Kernel.csproj", "src/Common/Common.Kernel/"]
COPY ["src/Common/Common.Messaging/Common.Messaging.csproj", "src/Common/Common.Messaging/"]

RUN dotnet restore "src/Services/Basket/Basket.API/Basket.API.csproj"

COPY . .

RUN dotnet build "src/Services/Basket/Basket.API/Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Services/Basket/Basket.API/Basket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Basket.API.dll"]