# Evaluación Continua 1 - Portal de Solicitudes de Servicio Técnico

## Descripción
Prototipo web para la empresa **TecnoGas Hogar** desarrollado en .NET 10 MVC con Entity Framework Core y SQLite.

## URLs de la Evaluación
* **Repositorio GitHub:** `https://github.com/TU_USUARIO/evaluacion20262`
* **Demo Publicado en Render:** `https://TU-APP.onrender.com`

## Configuración y Despliegue con Docker en Render
El proyecto utiliza Docker para asegurar el despliegue en Render.

1. **Dockerfile:** Utiliza el SDK de .NET para compilar la aplicación y la imagen AspNet Runtime para la ejecución.
2. **Base de Datos SQLite:** En `Program.cs` se incluyó `dbContext.Database.Migrate()` para crear la base de datos `tecnogas.db` y sus tablas automáticamente al iniciar la aplicación en el servidor.
3. **Estructura de Ramas:** Se utilizó el flujo GitFlow con la rama principal `main`, la rama `develop` y ramas de características (`feature/*`) integradas mediante Pull Requests.