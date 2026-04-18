FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["src/Services/Checkout/Checkout.API/Checkout.API.csproj", "src/Services/Checkout/Checkout.API/"]
COPY ["src/Services/Checkout/Checkout.Application/Checkout.Application.csproj", "src/Services/Checkout/Checkout.Application/"]
COPY ["src/Services/Checkout/Checkout.Domain/Checkout.Domain.csproj", "src/Services/Checkout/Checkout.Domain/"]
COPY ["src/Services/Checkout/Checkout.Infrastructure/Checkout.Infrastructure.csproj", "src/Services/Checkout/Checkout.Infrastructure/"]
COPY ["src/Common/Common.Kernel/Common.Kernel.csproj", "src/Common/Common.Kernel/"]
COPY ["src/Common/Common.Messaging/Common.Messaging.csproj", "src/Common/Common.Messaging/"]
COPY ["src/Common/Common.Logging/Common.Logging.csproj", "src/Common/Common.Logging/"]
COPY ["src/Common/Common.Metrics/Common.Metrics.csproj", "src/Common/Common.Metrics/"]

RUN dotnet restore "src/Services/Checkout/Checkout.API/Checkout.API.csproj"

COPY . .

RUN dotnet build "src/Services/Checkout/Checkout.API/Checkout.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Services/Checkout/Checkout.API/Checkout.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Checkout.API.dll"]