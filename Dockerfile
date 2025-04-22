# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia el archivo .csproj al contenedor (ajustada la ruta para reflejar la ubicación correcta)
COPY ["OnePieceWorld.csproj", "./"]

# Restaura las dependencias del proyecto
RUN dotnet restore "./OnePieceWorld.csproj"

# Copia el resto del código fuente
COPY . .

# Compila el proyecto
WORKDIR "/src"
RUN dotnet build "./OnePieceWorld.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OnePieceWorld.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app

# Copia el resultado de la publicación al contenedor final
COPY --from=publish /app/publish .

# Establece el comando predeterminado para ejecutar la aplicación
ENTRYPOINT ["dotnet", "OnePieceWorld.dll"]
