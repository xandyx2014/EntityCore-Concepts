## Comandos y Migraciones
Para estos comandos es necesario tener instalado `Microsoft.EntityFrameworkCore.Tools`
## Get-Help
`Get-Help Add-Migration` sirve para dar informacion que es lo que hace el comando
`Get-Help Add-MIgation -detailed` sirve para dar informacion muy detallada del comando 
## Add-Migration
`Add-Migration` para generacion archivos de las migraciones
## Update-Database
sirve para actualizar la base de datos de una migracion si no se le pasa niguno esta se agrega a una tbla qe se crea y guarda una entidad
- se le puede pasar una conectrion especifica
- se le puede pasar un context especifica
## Remove-Migration
se remueve la migracion 
## Get-Migration
podemos visualizar la migraciones ya aplicadas y si fueron aplicadas o no
## Drop-Database
sirve para borrar la base 
## Migrations Bunbles o Empaquetado
Cuando tenemos una DB en docker o en un servidor que no tiene .net core instalado o si tneemos un proceso de entrega continua pipeline
con migrations bunbles creamos un ejecutable para esto
- ` dotnet ef migrations bundle --configuration Bundle`
- `dotnet ef migrations bundle --configuration Bundle --force`
- `Bundle-Migration`
-  este creara uina archjivo efbundle.exe y ejecutamos `efbundle.exe --conection ""`
## Script-Migration
Genera el Sql  que puede ejecutarse en la base de datos
## Database.Migrate
- COn migrate podmeos aplicar las migracions desde nuestra aplicacion
- es simple
- debemos tener cuidado si la app se ejecuta en parelo
- si tarda mucho puede haber timeout en .net core
- carga lenta de la app
- si ay erorr es dificil para ejecutar
```c#
using var scope = app.Services.CreateScope();
var appDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
appDbContext.Database.Migrate();
```
## Modelos Compilados
cuando tenemos muchos modelos la carga se vuelve lente por eso entity core ha agregado Modelos compilados
- Nos permite optimizar nuestro modelos.
- No se recomienda usar si tnemos app con pocas entidades.
- No son compatbiles con lso filtros a nivel del modelo
- No son compatibles con lazy loading
- Cuando hagas cambios, tienes que recordar ejecutar un comandos
- `Optimize-DbContext`
## Database First
- `Scaffold-DbContext name=DefaultConnection -Provider Microsoft.EntityFrameworkCore.SqlServer -OuputDir Entidades`
- `Scaffold-DbContext name=DefaultConnection -Provider Microsoft.EntityFrameworkCore.SqlServer -OuputDir Entidades -Force`