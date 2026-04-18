FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["src/Services/Promotion/Promotion.Grpc/Promotion.Grpc.csproj", "src/Services/Promotion/Promotion.Grpc/"]
COPY ["src/Common/Common.Kernel/Common.Kernel.csproj", "src/Common/Common.Kernel/"]
COPY ["src/Common/Common.Logging/Common.Logging.csproj", "src/Common/Common.Logging/"]
COPY ["src/Common/Common.Metrics/Common.Metrics.csproj", "src/Common/Common.Metrics/"]

RUN dotnet restore "src/Services/Promotion/Promotion.Grpc/Promotion.Grpc.csproj"

COPY . .

RUN dotnet build "src/Services/Promotion/Promotion.Grpc/Promotion.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Services/Promotion/Promotion.Grpc/Promotion.Grpc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Promotion.Grpc.dll"]