# prueba-campuslands

Configurar la cadena de conexion que esta en el appsettings.Development.json para la base de datos SQL Server

Update-DataBase en la consola de administrador de paquetes para la creacion de la base de datos usando las migraciones

Scripts para correr para cargar unos productos
  Insert into Productos (Nombre, Precio, Stock, FechaCreacion)
  values ('media perla oro rosa', 25000, 25, GETDATE());

  Insert into Productos (Nombre, Precio, Stock, FechaCreacion)
  values ('pasador dorado', 155000, 25, GETDATE());

Para validar el ejemplo del JWT

Se usa el endpoint Login

para los usuarios
user: ivan
password: 123
rol: admin

user: dario
password: 321
rol: cliente

El cual devuelve un json con el token

  
