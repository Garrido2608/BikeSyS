# BikeSyS

API REST del taller de Bike Shop & Service, hecha con .NET 8, Entity Framework Core, SQL Server y JWT. Este README cuenta los cambios que se hicieron en la rama `collado` respecto de `master`.

## Cómo correrla

La clave del JWT ya no está en el repositorio, así que hay que configurarla antes de arrancar. Si no está o es muy corta, la API no inicia:

    cd ApiBikeSyS
    dotnet user-secrets set "Jwt:Key" "una-clave-larga-de-32-caracteres-o-mas"

La cadena de conexión se lee de `ConnectionStrings:ConexionSQL` en `appsettings.json`. Después se levanta con `dotnet run` y la documentación queda en `/swagger`.

La clave que tenía el proyecto antes estaba subida al repositorio, por lo que no conviene volver a usarla.

## Qué se cambió

Secretos: la clave del JWT y la cadena de conexión salieron del código. La clave se toma de User Secrets o de la variable de entorno `Jwt__Key`, y si falta la API no arranca.

Contraseñas: ahora se guardan con hash en lugar de texto plano, usando `PasswordHasher` de ASP.NET Core Identity. Las que ya estaban guardadas se convierten solas la primera vez que el usuario inicia sesión. Al actualizar un usuario la clave es opcional: si no se envía, no cambia.

Registro de usuarios: dejó de ser público. El primer usuario se crea sin token y los siguientes necesitan estar logueados.

Token: ahora usa la hora UTC para calcular el vencimiento.

Repuestos usados: la cantidad tiene que ser mayor a cero. Antes aceptaba números negativos y eso hacía subir el stock.

Mapeo: el perfil de AutoMapper pasó a la carpeta `Mappings`.

## Pruebas

Se probó a mano contra una base de prueba y todos los casos dieron el resultado esperado. No hay tests automáticos.
