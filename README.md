# Proyecto API en C# .NET

Este proyecto es una API desarrollada en C# utilizando el Framework .NET. Provee endpoints para control de inventario, conteniendo como base los productos, proveedores y lotes. 

## Requisitos

- .NET SDK 6.0 o superior
- Visual Studio 2022 o superior (opcional)
- SQL Server o MySql

### Paquetes NuGet utilizados
- Microsoft.AspNet.Cors
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools


## Instalación

1. Clona el repositorio:

    git clone https://github.com/tu-usuario/tu-repositorio.git
    cd tu-repositorio

2. Restaura los paquetes NuGet:

    dotnet restore

3. Configura la conexión a la base de datos en el archivo `appsettings.json`:

    {
        "Logging": {
            "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
            }
        },
        "AllowedHosts": "*",
        "ConnectionStrings": {
            "connection": "Server=tu-servidor;Database=tu-base-de-datos;User Id=tu-usuario;Password=tu-contraseña;"
        },
        "ApiKey": "crea-tu-apikey"
    }


6. Ejecuta la aplicación:

    dotnet run


## Guía de Uso

El URL : [link-api](http://www.api-inventory-management.somee.com)

La API ofrece los siguientes endpoints:

### Productos / Products

- **GET /product**: Obtiene todos los productos.
- **GET /product/id={id}**: Obtiene un producto por su ID.
- **POST /product/create**: Crea un nuevo producto.
- **PUT /product/edit/id={id}**: Actualiza un producto existente.
- **DELETE /product/delete/id={id}**: Elimina un producto.


### Proveedores / Suppliers

- **GET /supplier**: Obtiene todos los proveedores.
- **GET /supplier/id={id}**: Obtiene un proveedor por su ID.
- **POST /supplier/create**: Crea un nuevo proveedor.
- **PUT /supplier/edit/id={id}**: Actualiza un proveedor existente.
- **DELETE /supplier/delete/id={id}**: Elimina un proveedor.

### Lotes / Batch

- **GET /batch**: Obtiene todos los lotes.
- **GET /batch/id={id}**: Obtiene un lote por su ID.
- **POST /batch/create**: Crea un nuevo lote.
- **PUT /batch/edit/id={id}**: Actualiza un lote existente.
- **DELETE /batch/delete/id={id}**: Elimina un lote.

