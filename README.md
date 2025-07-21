# Catálogo de Productos Aranda

Una API REST para la gestión de un catálogo de productos desarrollada con ASP.NET Web API 2, siguiendo los principios de Clean Architecture, SOLID y patrones de diseño.

> 📚 **Documentación interactiva disponible**: Esta API incluye documentación Swagger interactiva que puedes acceder en `/swagger` una vez que ejecutes la aplicación.

## 🏗️ Arquitectura

El proyecto está estructurado en capas siguiendo Clean Architecture:

- **`Aranda.Productos.Api`**: Capa de presentación (Web API)
- **`Aranda.Productos.Application`**: Capa de aplicación (servicios, DTOs, validaciones)
- **`Aranda.Productos.Domain`**: Capa de dominio (entidades, interfaces)
- **`Aranda.Productos.Infrastructure`**: Capa de infraestructura (repositorios, base de datos)
- **`Aranda.Productos.Api.Tests`**: Pruebas unitarias

## 🛠️ Tecnologías

- **.NET Framework 4.7.2**
- **ASP.NET Web API 2**
- **Entity Framework 6.5.1**
- **AutoMapper 10.1.1**
- **FluentValidation 10.4.0**
- **Unity Container** (Inyección de dependencias)
- **Swashbuckle** (Documentación API)
- **SQL Server LocalDB**

## 📋 Requisitos

- **Visual Studio 2019** o superior
- **.NET Framework 4.7.2** o superior
- **SQL Server LocalDB** (incluido con Visual Studio)
- **NuGet Package Manager**

## ⚙️ Configuración e Instalación

### 1. Clonar el repositorio
```bash
git clone [url-del-repositorio]
cd CatalogoDeProductosAranda
```

### 2. Restaurar paquetes NuGet
```bash
nuget restore CatalogoDeProductosAranda.sln
```

### 3. Configurar la base de datos

La aplicación utiliza SQL Server LocalDB con Entity Framework Code First. La cadena de conexión está configurada en el `Web.config`:

```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ArandaProductsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Ejecutar migraciones

En la **Consola del Administrador de Paquetes** de Visual Studio, seleccionamos la capa de infraestructura:
<img width="815" height="154" alt="image" src="https://github.com/user-attachments/assets/7c5af6a1-b1c0-47f2-b0ae-a0d848197a53" />

```powershell
Update-Database
```

### 5. Compilar y ejecutar

1. Establece `Aranda.Productos.Api` como proyecto de inicio
2. Presiona `F5` o `Ctrl+F5` para ejecutar
3. La API estará disponible en: `https://localhost:44301/` (puerto puede variar)

## 📚 Documentación de la API

### Base URL
```
https://localhost:44301/api/products
```

### Documentación Swagger
```
https://localhost:44301/swagger
```

---

## 🔗 Endpoints

### 1. Obtener productos (con paginación y filtros)

**GET** `/api/products`

Obtiene una lista paginada y filtrada de productos.

#### Parámetros de consulta (Query Parameters)

| Parámetro | Tipo | Descripción | Valor por defecto |
|-----------|------|-------------|-------------------|
| `Filter` | string | Filtro de búsqueda por nombre o descripción | - |
| `SortBy` | string | Campo para ordenar (nombre, descripcion, categoria) | `nombre` |
| `SortOrder` | string | Orden ascendente (`asc`) o descendente (`desc`) | `asc` |
| `Page` | int | Número de página (mínimo 1) | `1` |
| `PageSize` | int | Elementos por página (máximo 100) | `10` |

#### Ejemplo de solicitud
```http
GET /api/products?Filter=laptop&SortBy=nombre&SortOrder=asc&Page=1&PageSize=5
```

#### Respuesta exitosa (200 OK)
```json
{
  "Data": [
    {
      "Id": 1,
      "Nombre": "Laptop HP",
      "Descripcion": "Laptop HP con procesador Intel i5",
      "Categoria": "Computadoras",
      "Imagen": "laptop-hp.jpg"
    }
  ],
  "PageNumber": 1,
  "PageSize": 5,
  "TotalRecords": 1,
  "TotalPages": 1
}
```

---

### 2. Obtener producto por ID

**GET** `/api/products/{id}`

Obtiene un producto específico por su ID.

#### Parámetros de ruta

| Parámetro | Tipo | Descripción |
|-----------|------|-------------|
| `id` | int | ID del producto |

#### Ejemplo de solicitud
```http
GET /api/products/1
```

#### Respuesta exitosa (200 OK)
```json
{
  "Id": 1,
  "Nombre": "Laptop HP",
  "Descripcion": "Laptop HP con procesador Intel i5",
  "Categoria": "Computadoras",
  "Imagen": "laptop-hp.jpg"
}
```

#### Respuesta cuando no se encuentra (404 Not Found)
```json
{
  "Message": "No HTTP resource was found that matches the request URI."
}
```

---

### 3. Crear producto

**POST** `/api/products`

Crea un nuevo producto.

#### Cuerpo de la solicitud (JSON)
```json
{
  "Nombre": "Laptop Dell",
  "Descripcion": "Laptop Dell Inspiron 15",
  "CategoriaId": 1,
  "Imagen": "laptop-dell.jpg"
}
```

#### Modelo CreateProductDto

| Campo | Tipo | Obligatorio | Descripción |
|-------|------|-------------|-------------|
| `Nombre` | string | Sí | Nombre del producto |
| `Descripcion` | string | Sí | Descripción del producto |
| `CategoriaId` | int | Sí | ID de la categoría |
| `Imagen` | string | No | Nombre del archivo de imagen |

#### Ejemplo de solicitud
```http
POST /api/products
Content-Type: application/json

{
  "Nombre": "Laptop Dell",
  "Descripcion": "Laptop Dell Inspiron 15",
  "CategoriaId": 1,
  "Imagen": "laptop-dell.jpg"
}
```

#### Respuesta exitosa (201 Created)
```json
{
  "Id": 2,
  "Nombre": "Laptop Dell",
  "Descripcion": "Laptop Dell Inspiron 15",
  "Categoria": "Computadoras",
  "Imagen": "laptop-dell.jpg"
}
```

#### Headers de respuesta
```
Location: /api/products/2
```

#### Respuesta de error de validación (400 Bad Request)
```json
{
  "Message": "Mensaje de error de validación"
}
```

---

### 4. Actualizar producto

**PUT** `/api/products/{id}`

Actualiza un producto existente.

#### Parámetros de ruta

| Parámetro | Tipo | Descripción |
|-----------|------|-------------|
| `id` | int | ID del producto a actualizar |

#### Cuerpo de la solicitud (JSON)
```json
{
  "Nombre": "Laptop Dell Actualizada",
  "Descripcion": "Laptop Dell Inspiron 15 - Actualizada",
  "CategoriaId": 1,
  "Imagen": "laptop-dell-nueva.jpg"
}
```

#### Modelo UpdateProductDto

| Campo | Tipo | Obligatorio | Descripción |
|-------|------|-------------|-------------|
| `Nombre` | string | Sí | Nombre del producto |
| `Descripcion` | string | Sí | Descripción del producto |
| `CategoriaId` | int | Sí | ID de la categoría |
| `Imagen` | string | No | Nombre del archivo de imagen |

#### Ejemplo de solicitud
```http
PUT /api/products/2
Content-Type: application/json

{
  "Nombre": "Laptop Dell Actualizada",
  "Descripcion": "Laptop Dell Inspiron 15 - Actualizada",
  "CategoriaId": 1,
  "Imagen": "laptop-dell-nueva.jpg"
}
```

#### Respuesta exitosa (204 No Content)
Sin contenido en el cuerpo de la respuesta.

#### Respuesta cuando no se encuentra (404 Not Found)
```json
{
  "Message": "No HTTP resource was found that matches the request URI."
}
```

#### Respuesta de error de validación (400 Bad Request)
```json
{
  "Message": "Mensaje de error de validación"
}
```

---

### 5. Eliminar producto

**DELETE** `/api/products/{id}`

Elimina un producto por su ID.

#### Parámetros de ruta

| Parámetro | Tipo | Descripción |
|-----------|------|-------------|
| `id` | int | ID del producto a eliminar |

#### Ejemplo de solicitud
```http
DELETE /api/products/2
```

#### Respuesta exitosa (204 No Content)
Sin contenido en el cuerpo de la respuesta.

#### Respuesta cuando no se encuentra (404 Not Found)
```json
{
  "Message": "No HTTP resource was found that matches the request URI."
}
```

---

## 📝 Modelos de Datos

### ProductDto (Respuesta)
```json
{
  "Id": 1,
  "Nombre": "string",
  "Descripcion": "string",
  "Categoria": "string",
  "Imagen": "string"
}
```

### CreateProductDto (Solicitud POST)
```json
{
  "Nombre": "string",
  "Descripcion": "string",
  "CategoriaId": 1,
  "Imagen": "string"
}
```

### UpdateProductDto (Solicitud PUT)
```json
{
  "Nombre": "string",
  "Descripcion": "string",
  "CategoriaId": 1,
  "Imagen": "string"
}
```

### PagedResponse (Lista paginada)
```json
{
  "Data": [ProductDto],
  "PageNumber": 1,
  "PageSize": 10,
  "TotalRecords": 100,
  "TotalPages": 10
}
```

---

## 🧪 Pruebas

Para ejecutar las pruebas unitarias:

1. En Visual Studio: **Test > Run All Tests**
2. O usando la línea de comandos:
```bash
dotnet test
```

---

## 🔧 Características adicionales

- **Validación automática** con FluentValidation
- **Manejo global de excepciones**
- **Inyección de dependencias** con Unity Container
- **Mapeo automático** con AutoMapper
- **Documentación automática** con Swagger
- **Filtros de acción** para validaciones
- **Paginación y filtrado** en listados
- **Arquitectura en capas** (Clean Architecture)

---

## 📁 Estructura del proyecto

```
CatalogoDeProductosAranda/
├── Aranda.Productos.Api/           # API Web (Controllers, Filters, Config)
├── Aranda.Productos.Application/   # Servicios, DTOs, Validadores
├── Aranda.Productos.Domain/        # Entidades, Interfaces de dominio
├── Aranda.Productos.Infrastructure/ # Repositorios, DbContext, Migrations
└── Aranda.Productos.Api.Tests/     # Pruebas unitarias
```

---

## 🤝 Contribuir

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para detalles. 
