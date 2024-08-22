FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MarqueeBackend.Api/MarqueeBackend.Api.csproj", "MarqueeBackend.Api/"]
COPY ["MarqueeBackend.DataService/MarqueeBackend.DataService.csproj", "MarqueeBackend.DataService/"]
COPY ["MarqueeBackend.Entities/MarqueeBackend.Entities.csproj", "MarqueeBackend.Entities/"]
RUN dotnet restore "MarqueeBackend.Api/MarqueeBackend.Api.csproj"

# Copy source code
COPY . .

# Build
WORKDIR "/src/MarqueeBackend.Api"
RUN dotnet build "MarqueeBackend.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MarqueeBackend.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "MarqueeBackend.Api.dll" ]