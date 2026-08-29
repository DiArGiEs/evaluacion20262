# 1. Etapa de compilación (Build)
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copiar el archivo del proyecto y restaurar dependencias
COPY ["evaluacion20262.csproj", "./"]
RUN dotnet restore "evaluacion20262.csproj"

# Copiar todo el código fuente y compilar
COPY . .
RUN dotnet publish "evaluacion20262.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 2. Etapa de ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS final
WORKDIR /app

# Copiar la aplicación compilada desde la etapa anterior
COPY --from=build /app/publish .

# Exponer el puerto por defecto de ASP.NET Core
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Comando para arrancar la aplicación
ENTRYPOINT ["dotnet", "evaluacion20262.dll"]