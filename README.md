# Casa de Refrigeración: API (backend)

API del sistema para un local de refrigeración. Trabajo de EDI 3.
Hecha con ASP.NET Web API (.NET 10), EF Core, SQL Server y JWT.

El frontend está en [ProyectoCasaRefrigeracionFrontEnd](https://github.com/Jonybenigni/ProyectoCasaRefrigeracionFrontEnd).

## Qué hace falta

- SDK de **.NET 10**
- **SQL Server Express** en la misma PC (instancia `SQLEXPRESS`)

## Cómo levantarla

1. Abrir `Refrigeracion.slnx` en Visual Studio.
2. Dejar `Refrigeracion.WebApi` como proyecto de inicio y el perfil `https`.
3. Ejecutar con F5.

También se puede desde una terminal, en la carpeta de la solución:

```bash
dotnet run --project Refrigeracion.WebApi --launch-profile https
```

Al arrancar por primera vez **se crea sola la base `RefrigeracionDB`**, con todas sus tablas, y el usuario para entrar. No hace falta correr migraciones.

La API queda en `https://localhost:7133` y Swagger en `https://localhost:7133/swagger`.

## Usuario para entrar

- Email: `admin@refrigeracion.com`
- Contraseña: `Refri2026!`

## Si el servidor de base de datos es otro

Crear el archivo `Refrigeracion.WebApi/appsettings.Local.json` con la conexión de esa PC (este archivo no se sube al repositorio):

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=NOMBRE_DEL_SERVIDOR;Database=RefrigeracionDB;Trusted_Connection=True;TrustServerCertificate=True"
    }
}
```

## Nota sobre las claves

La clave del JWT y el usuario inicial de `appsettings.json` son de práctica, para que el proyecto funcione al bajarlo. En un sistema real se generan otras y se guardan en variables de entorno.
