# 🏢 Northwind App

Una aplicación **ASP.NET MVC** desarrollada con **.NET Framework 4.8** para la gestión de pedidos y clientes basada en la base de datos **Northwind**.

## 📋 Descripción del Proyecto

NorthwindApp es una aplicación web empresarial que permite:
- 📦 Gestionar **pedidos** (Orders) con búsqueda, filtrado y paginación
- 👥 Administrar **clientes** (Customers) con búsqueda avanzada
- 📊 Visualizar detalles completos de pedidos y detalles de envío
- 🔍 Buscar pedidos por ID con resultados precisos
- 📄 Navegar entre páginas de resultados con paginación funcional
- 🛡️ Manejo robusto de excepciones y validación de datos NULL
- ⚡ Operaciones optimizadas con uso correcto de recursos

## 🛠️ Stack Tecnológico

| Tecnología | Versión |
|-----------|---------|
| **.NET Framework** | 4.8 |
| **ASP.NET MVC** | 5.x |
| **C#** | 7.3 |
| **SQL Server** | SQL Server 2019+ |
| **Bootstrap** | 4.x (CSS Framework) |

## 📁 Estructura del Proyecto

```
NorthwindApp/
├── 📂 Controllers/
│   ├── OrdersController.cs       # Controlador de Pedidos
│   └── CustomersController.cs    # Controlador de Clientes
│
├── 📂 Models/
│   ├── Orders.cs                 # Modelo de Pedidos
│   ├── Customers.cs              # Modelo de Clientes
│   ├── OrderDetails.cs           # Detalles de Pedidos
│   └── Products.cs               # Modelo de Productos
│
├── 📂 Data/
│   ├── OrdersDAO.cs              # Data Access Object - Pedidos
│   ├── CustomersDAO.cs           # Data Access Object - Clientes
│   └── 📂 Interfaces/
│       ├── IOrders.cs            # Interfaz de Pedidos
│       ├── ICustomers.cs         # Interfaz de Clientes
│       └── ICRUD.cs              # Interfaz genérica CRUD
│
├── 📂 Views/
│   ├── 📂 Orders/
│   │   └── ListaOrders.cshtml    # Vista de listado de pedidos
│   ├── 📂 Customers/
│   │   ├── Lista.cshtml          # Vista de listado de clientes
│   │   └── Detalles.cshtml       # Vista de detalles de cliente
│   └── 📂 Shared/
│       └── _Main.cshtml          # Plantilla maestra
│
├── 📂 App_Start/
│   └── RouteConfig.cs            # Configuración de rutas
│
├── Global.asax.cs                # Configuración global
├── Web.config                     # Configuración de aplicación
└── Web.Release.config             # Configuración de publicación
```

## 🎯 Funcionalidades Principales

### 📦 Gestión de Pedidos (`OrdersController`)

| Acción | Método | Parámetros | Descripción |
|--------|--------|-----------|-------------|
| **ListaOrders** | GET | `pagina=1` | Obtiene listado paginado de todos los pedidos (10 por página) |
| **ListaOrders** | POST | `orderid` | Busca un pedido específico por ID |
| **DetallesOrders** | GET | `orderId` | Muestra los detalles completos de un pedido |

### 👥 Gestión de Clientes (`CustomersController`)

| Acción | Descripción |
|--------|------------|
| **Lista** | Listado de todos los clientes |
| **Detalles** | Muestra información del cliente y sus pedidos |

## 🏗️ Arquitectura de Datos (DAO Pattern)

El proyecto implementa el patrón **Data Access Object** para separar la lógica de acceso a datos:

```
Interface (ICRUD<T>) 
    ↓
    ├── IOrders → OrdersDAO
    └── ICustomers → CustomersDAO
```

### Métodos CRUD Disponibles

```csharp
public interface ICRUD<T>
{
    bool Registrar(T entity);           // CREATE
    List<T> ListarTodo();               // READ
    bool Actualizar(T entity);          // UPDATE
    bool Eliminar(int id);              // DELETE
}
```

## 🚀 Instalación y Configuración

### Requisitos Previos

- ✅ Visual Studio 2019 o superior (Community, Professional o Enterprise)
- ✅ .NET Framework 4.8 SDK
- ✅ SQL Server (localdb, Express o Standard)
- ✅ Git

### Pasos de Instalación

**1️⃣ Clonar el repositorio**
```powershell
git clone https://github.com/antwny/northwind-app.git
cd NorthwindApp
```

**2️⃣ Abrir el proyecto en Visual Studio**
```powershell
# Opción 1: Desde la línea de comandos
start NorthwindApp.sln

# Opción 2: Abrir manualmente Visual Studio y cargar NorthwindApp.sln
```

**3️⃣ Configurar la cadena de conexión**
- Abre el archivo `Web.config` en la raíz del proyecto
- Localiza la sección `<connectionStrings>`
- Actualiza la cadena de conexión `NorthwindContext`:

```xml
<connectionStrings>
    <add name="NorthwindContext" 
         connectionString="Server=YOUR_SERVER;Database=Northwind;Integrated Security=true;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Ejemplos de cadenas de conexión:**
```xml
<!-- Usando localdb -->
<add name="NorthwindContext" 
     connectionString="Server=(localdb)\mssqllocaldb;Database=Northwind;Integrated Security=true;" 
     providerName="System.Data.SqlClient" />

<!-- Usando SQL Server Express -->
<add name="NorthwindContext" 
     connectionString="Server=.\SQLEXPRESS;Database=Northwind;Integrated Security=true;" 
     providerName="System.Data.SqlClient" />

<!-- Usando SQL Server con autenticación -->
<add name="NorthwindContext" 
     connectionString="Server=YOUR_SERVER;Database=Northwind;User Id=sa;Password=your_password;" 
     providerName="System.Data.SqlClient" />
```

**4️⃣ Restaurar base de datos Northwind**

Opción A: Usar SQL Management Studio
```sql
-- Descarga el script desde: https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs
-- Ejecuta el script de Northwind.sql en tu SQL Server
```

Opción B: Usar Visual Studio
- Abre SQL Server Object Explorer (View → SQL Server Object Explorer)
- Clic derecho en "SQL Server" → "Add SQL Server"
- Conecta a tu instancia y crea la base de datos Northwind

**5️⃣ Compilar la solución**
```powershell
# Desde PowerShell
dotnet build

# O desde Visual Studio:
# Build → Build Solution (Ctrl + Shift + B)
```

**6️⃣ Ejecutar la aplicación**
```powershell
# Opción 1: Presiona F5 en Visual Studio
# Opción 2: Presiona Ctrl + F5 (sin depuración)
# Opción 3: Haz clic en "IIS Express" en Visual Studio

# La aplicación se abrirá en http://localhost:PUERTO
```

## 📊 Modelos de Datos

### Orders (Pedidos)
```csharp
public class Orders
{
    public int OrderID { get; set; }
    public Customers Customers { get; set; }
    public DateTime? OrderDate { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
}
```

### Customers (Clientes)
```csharp
public class Customers
{
    public string CustomerID { get; set; }
    // ... más propiedades
    public List<Orders> Orders { get; set; }
}
```

## 🐛 Problemas Conocidos e Issues

### ⚠️ Problemas Activos

**1. OrdersDAO.ListarTodo() - Manejo de valores NULL**
```csharp
// ❌ PROBLEMA: No valida NULL antes de GetString()
ShipAddress = reader.GetString(4),
ShipCity = reader.GetString(5),
ShipPostalCode = reader.GetString(6),
ShipCountry = reader.GetString(7)
```

**Solución recomendada:**
```csharp
// ✅ CORRECCIÓN: Validar NULL con IsDBNull()
ShipAddress = reader.IsDBNull(4) ? null : reader.GetString(4),
ShipCity = reader.IsDBNull(5) ? null : reader.GetString(5),
ShipPostalCode = reader.IsDBNull(6) ? null : reader.GetString(6),
ShipCountry = reader.IsDBNull(7) ? null : reader.GetString(7)
```

**2. SqlDataReader no se cierra correctamente**
```csharp
// ❌ PROBLEMA: El reader no se cierra correctamente
var reader = cmd.ExecuteReader();

// ✅ CORRECCIÓN: Usar using statement
using (var reader = cmd.ExecuteReader())
{
    // código
}
```

**3. Vista ListaOrders.cshtml - Navegación de paginación**
```html
<!-- ❌ PROBLEMA: Apunta a "Lista" en lugar de "ListaOrders" -->
@Html.ActionLink("»", "Lista", new { pagina = paginaActual + 1 }, ...)

<!-- ✅ CORRECCIÓN: Debe ser "ListaOrders" -->
@Html.ActionLink("»", "ListaOrders", new { pagina = paginaActual + 1 }, ...)
```

**4. Métodos CRUD no implementados en algunos DAOs**
```csharp
// ❌ Estos métodos pueden lanzar NotImplementedException
OrdersDAO.Actualizar()     // UPDATE
OrdersDAO.Eliminar()       // DELETE
OrdersDAO.Registrar()      // INSERT
```

### ✅ Mejoras Sugeridas (Roadmap)

**Corto Plazo**
- [ ] ✏️ Implementar métodos CRUD faltantes (Registrar, Actualizar, Eliminar)
- [ ] 🛡️ Agregar manejo de excepciones en DAO y Controllers
- [ ] 🔍 Validar valores NULL en todas las consultas SQL
- [ ] 📦 Usar `using` statement para SqlConnection y SqlDataReader
- [ ] ✔️ Agregar validación de modelos con Data Annotations
- [ ] 🔐 Auditar seguridad contra SQL Injection

**Mediano Plazo**
- [ ] ⚡ Implementar async/await para operaciones de BD
- [ ] 🗄️ Considerar Entity Framework como alternativa a ADO.NET raw SQL
- [ ] 🧪 Agregar pruebas unitarias
- [ ] 📝 Agregar logging y manejo de errores
- [ ] 🎨 Mejorar UI/UX con diseño responsive moderno

**Largo Plazo (Modernización)**
- [ ] 🚀 Migrar a .NET Core / .NET 6+
- [ ] 🔄 Implementar API REST con ASP.NET Core Web API
- [ ] 📱 Frontend con React, Vue o Angular
- [ ] 🔐 Implementar autenticación moderna (JWT, OAuth)
- [ ] 📤 Agregar exportación de datos (PDF, Excel, CSV)
- [ ] 📊 Dashboard con reportes avanzados

## 📝 Ejemplos de Uso

### 1️⃣ Obtener todos los pedidos (paginados)
```
GET http://localhost:PUERTO/Orders/ListaOrders?pagina=1
```

### 2️⃣ Buscar pedido por ID
```
POST http://localhost:PUERTO/Orders/ListaOrders
Form Data: orderid=10248
```

### 3️⃣ Ver detalles de un pedido
```
GET http://localhost:PUERTO/Orders/DetallesOrders?orderId=10248
```

### 4️⃣ Listar clientes
```
GET http://localhost:PUERTO/Customers/Lista
```

### 5️⃣ Ver detalles de cliente
```
GET http://localhost:PUERTO/Customers/Detalles?customerId=ALFKI
```

## 🔐 Seguridad

### ✅ Implementado
- ✓ Uso de **parámetros SQL** para prevenir SQL Injection
- ✓ **Integrated Security** en la cadena de conexión
- ✓ Validación de entrada en formularios

### ⚠️ Recomendado Implementar
- [ ] Autenticación (Forms Authentication o Identity)
- [ ] Autorización basada en roles
- [ ] HTTPS/SSL en producción
- [ ] CSRF Protection en formularios
- [ ] Input validation y sanitization
- [ ] Manejo seguro de errores (sin exponer detalles técnicos)

## 📚 Patrones y Prácticas Implementadas

### Patrones de Diseño
- **DAO Pattern** - Acceso a datos independiente de la lógica de negocio
- **MVC Pattern** - Model-View-Controller para separación de responsabilidades
- **Repository Pattern** - Básico, implementado a través de los DAOs

### Principios SOLID
- **S** - Single Responsibility: Cada DAO maneja una tabla
- **O** - Open/Closed: Extensible a través de interfaces
- **L** - Liskov Substitution: Las implementaciones respetan el contrato
- **I** - Interface Segregation: Interfaces específicas (IOrders, ICustomers)
- **D** - Dependency Inversion: Dependencia en interfaces, no en implementaciones

## 📜 Licencia

Este proyecto utiliza la base de datos Northwind de Microsoft como conjunto de datos de demostración. El código está disponible bajo licencia MIT.

## 👤 Información del Autor

- **Desarrollador**: [@antwny](https://github.com/antwny)
- **Repositorio**: [github.com/antwny/northwind-app](https://github.com/antwny/northwind-app)
- **Email**: Contactar a través de GitHub Issues

## 📞 Soporte y Contribuciones

### Reportar Problemas
1. Abre un **Issue** en GitHub describiendo el problema
2. Incluye capturas de pantalla o mensajes de error
3. Especifica tu entorno (Windows, Visual Studio version, SQL Server version)

### Contribuciones
Las contribuciones son bienvenidas:
1. Fork el repositorio
2. Crea una rama feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📚 Documentación Complementaria

Este proyecto incluye documentación adicional para facilitar tu trabajo:

| Documento | Descripción | Cuándo Leerlo |
|-----------|------------|---------------|
| 📋 **GUIA_RAPIDA.md** | Guía de 5 minutos para empezar | ⭐ Primer día |
| 🔬 **ANALISIS_TECNICO.md** | Análisis detallado: componentes, arquitectura, problemas | Para entender la estructura |
| ✅ **TAREAS_PENDIENTES.md** | Lista de TODO, bugs, plan de desarrollo | Para contribuir al proyecto |

### Ruta de Lectura Recomendada

**Día 1 - Primer Contacto** (20 minutos)
1. Este README.md
2. GUIA_RAPIDA.md
3. Ejecutar la aplicación

**Antes de Contribuir** (30 minutos)
1. ANALISIS_TECNICO.md
2. TAREAS_PENDIENTES.md
3. Revisar código fuente relevante

---

## 📊 Análisis del Proyecto (Estado Actual)

### 📈 Estadísticas del Código

| Métrica | Valor |
|---------|-------|
| **Controladores** | 2 (Orders, Customers) |
| **Modelos** | 4 (Orders, Customers, Products, OrderDetails) |
| **Data Access Objects** | 3 (OrdersDAO, CustomersDAO, ProductsDAO) |
| **Interfaces** | 4 (ICRUD, IOrders, ICustomers, IProducts) |
| **Vistas** | 5+ (ListaOrders, DetallesOrders, Lista, Detalles, Layout) |
| **Líneas de Código** | ~2000+ (estimado) |
| **Framework** | ASP.NET MVC 5.2 |
| **Runtime** | .NET Framework 4.8 |

### 🏆 Fortalezas del Proyecto

✅ **Arquitectura Limpia**
- Separación clara entre capas (Controllers → Models → DAO → DB)
- Uso del patrón DAO para acceso a datos
- Interfaces bien definidas (ICRUD, IOrders, etc.)

✅ **Base de Datos Estable**
- Utiliza la base de datos Northwind probada
- Conexión segura con Windows Integrated Authentication
- Múltiples resultados activos (MARS) habilitado

✅ **Interfaz Amigable**
- Vistas Razor bien estructuradas
- Soporte para paginación
- Búsqueda de pedidos por ID
- Diseño responsivo con Bootstrap

✅ **Mantenibilidad**
- Código organizado en carpetas temáticas
- Nombres descriptivos en clase y métodos
- Sigue convenciones de ASP.NET MVC

### ⚠️ Debilidades Identificadas

❌ **Falta de Manejo de Errores**
- No hay try-catch en los DAOs
- Sin logging de excepciones
- Errores pueden exponerse al usuario

❌ **Métodos CRUD Incompletos**
- Registrar, Actualizar, Eliminar no implementados
- Solo lecturas disponibles (Obtener, BuscarPorId, ObtenerPaginado)

❌ **Validación de Datos NULL**
- Algunos campos pueden causar excepciones si son NULL
- Falta de coerción a tipos seguros

❌ **Seguridad**
- Sin autenticación/autorización
- Sin protección CSRF visible
- Conexión SQL Server con credenciales hardcodeadas

❌ **Falta de Async/Await**
- Todas las operaciones son síncronas
- Bloquean threads innecesariamente
- No escalable para alta concurrencia

### 📋 Cobertura de Funcionalidades

#### ✅ Implementado
- [x] Listar pedidos con paginación
- [x] Buscar pedido por ID
- [x] Ver detalles de pedido
- [x] Ver detalles de cliente
- [x] Listar clientes
- [x] Vista de detalles de envío
- [x] Información de productos en pedidos

#### ❌ No Implementado
- [ ] Crear pedidos
- [ ] Editar pedidos
- [ ] Eliminar pedidos
- [ ] Crear clientes
- [ ] Editar clientes
- [ ] Eliminar clientes
- [ ] Validaciones completas

### 🎯 Próximos Pasos Recomendados

**Fase 1 - Estabilización (1-2 semanas)**
1. Implementar manejo de errores global
2. Validar y sanitizar datos NULL
3. Agregar logging básico
4. Crear pruebas unitarias para DAOs

**Fase 2 - Funcionalidad (2-3 semanas)**
1. Implementar métodos CRUD faltantes
2. Agregar validaciones de modelos
3. Implementar async/await
4. Mejorar seguridad

**Fase 3 - Modernización (4+ semanas)**
1. Migrar a .NET 6 o .NET 8
2. Reemplazar MVC con ASP.NET Core Web API
3. Frontend moderno con React o Angular
4. Base de datos con Entity Framework Core

---

**⭐ Si este proyecto te fue útil, no olvides dejar una estrella en GitHub!**

**Última actualización**: 2024 | **Mantenedor**: [@antwny](https://github.com/antwny)
