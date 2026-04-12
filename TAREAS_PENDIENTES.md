# 📋 LISTA DE PENDIENTES - NorthwindApp

## Estado General del Proyecto
- **Versión**: 1.0 (Inicial)
- **Última Actualización**: 2024
- **Estado**: ⚠️ En Desarrollo (Necesita Estabilización)
- **Prioridad General**: 🔴 ALTA

---

## 🔴 CRÍTICO - Debe hacerse AHORA

### 1. Validación de Valores NULL
- **Archivo**: `Data/OrdersDAO.cs`
- **Línea aprox**: Método `Obtener()` o `ListarTodo()`
- **Problema**: `reader.GetString()` falla si el valor es NULL
- **Solución**: 
  ```csharp
  ShipAddress = reader.IsDBNull(4) ? null : reader.GetString(4),
  ```
- **Esfuerzo**: 30 minutos
- **Estado**: ⏳ No Iniciado
- **Asignado a**: [@antwny](https://github.com/antwny)

---

### 2. Manejo Global de Excepciones
- **Ubicación**: Todos los métodos DAO
- **Problema**: Sin try-catch, errores técnicos expuestos al usuario
- **Solución**: Agregar try-catch y logging
- **Esfuerzo**: 1-2 horas
- **Estado**: ⏳ No Iniciado
- **Prioridad**: 🔴 CRÍTICA

Ejemplo:
```csharp
public List<Orders> Obtener()
{
    try
    {
        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            // código
        }
    }
    catch (Exception ex)
    {
        // Log error
        throw;
    }
}
```

---

### 3. Liberar Recursos de BD
- **Ubicación**: Todos los DAOs
- **Problema**: SqlConnection y SqlDataReader no se cierran
- **Solución**: Usar `using` statements
- **Esfuerzo**: 2-3 horas
- **Estado**: ⏳ No Iniciado
- **Prioridad**: 🔴 CRÍTICA

Patrón correcto:
```csharp
using (SqlConnection conexion = new SqlConnection(cadenaConexion))
using (SqlCommand cmd = new SqlCommand(sql, conexion))
using (SqlDataReader reader = cmd.ExecuteReader())
{
    // código
}
```

---

### 4. Corregir Enlaces de Paginación
- **Archivo**: `Views/Orders/ListaOrders.cshtml`
- **Problema**: ActionLink apunta a "Lista" en lugar de "ListaOrders"
- **Solución**:
  ```csharp
  @Html.ActionLink("»", "ListaOrders", new { pagina = paginaActual + 1 })
  ```
- **Esfuerzo**: 15 minutos
- **Estado**: ⏳ No Iniciado
- **Prioridad**: 🔴 CRÍTICA

---

## 🟡 ALTO - Debe hacerse esta semana

### 5. Implementar Métodos CRUD - Registrar
- **Archivo**: `Data/OrdersDAO.cs`
- **Método**: `Registrar(Orders obj)`
- **Tipo**: INSERT
- **Esfuerzo**: 1-2 horas
- **Estado**: ⏳ No Iniciado
- **Descripción**: Permitir crear nuevos pedidos

Pasos:
1. [ ] Crear método en interfaz `IOrders`
2. [ ] Implementar en `OrdersDAO`
3. [ ] Crear acción en `OrdersController` (GET para formulario)
4. [ ] Crear acción (POST) para guardar
5. [ ] Crear vista `Create.cshtml`
6. [ ] Validar datos de entrada

---

### 6. Implementar Métodos CRUD - Actualizar
- **Archivo**: `Data/OrdersDAO.cs`
- **Método**: `Actualizar(Orders obj)`
- **Tipo**: UPDATE
- **Esfuerzo**: 1-2 horas
- **Estado**: ⏳ No Iniciado
- **Descripción**: Permitir editar pedidos existentes

Pasos:
1. [ ] Crear método en interfaz `IOrders`
2. [ ] Implementar en `OrdersDAO`
3. [ ] Crear acción GET `Edit(int id)` en Controller
4. [ ] Crear acción POST `Edit(Orders obj)` en Controller
5. [ ] Crear vista `Edit.cshtml`

---

### 7. Implementar Métodos CRUD - Eliminar
- **Archivo**: `Data/OrdersDAO.cs`
- **Método**: `Eliminar(int id)`
- **Tipo**: DELETE
- **Esfuerzo**: 1 hora
- **Estado**: ⏳ No Iniciado
- **Descripción**: Permitir eliminar pedidos

Pasos:
1. [ ] Crear método en interfaz `IOrders`
2. [ ] Implementar en `OrdersDAO`
3. [ ] Agregar botón Eliminar en vista
4. [ ] Crear confirmación de eliminación

---

### 8. Agregar Logging Básico
- **Ubicación**: Global
- **Opción 1**: Usar `System.Diagnostics.EventLog`
- **Opción 2**: Crear logger simple en archivo
- **Esfuerzo**: 1-2 horas
- **Estado**: ⏳ No Iniciado

```csharp
// Logger simple
public static class Logger
{
    public static void LogError(string message, Exception ex)
    {
        File.AppendAllText("error.log", $"{DateTime.Now}: {message}\n{ex}\n");
    }
}
```

---

## 🟢 MEDIO - Debería hacerse este mes

### 9. Autenticación de Usuarios
- **Ubicación**: Global
- **Opciones**: 
  - [ ] Forms Authentication (tradicional)
  - [ ] ASP.NET Identity (moderno)
  - [ ] Azure AD (empresarial)
- **Esfuerzo**: 3-4 horas
- **Estado**: ⏳ No Iniciado
- **Descripción**: Requerir login para acceder

Pasos:
1. [ ] Crear tabla `Users` en BD
2. [ ] Crear modelo `User`
3. [ ] Crear LoginController
4. [ ] Crear vista Login.cshtml
5. [ ] Agregar `[Authorize]` en controladores

---

### 10. Async/Await en DAOs
- **Ubicación**: Todos los DAOs
- **Esfuerzo**: 4-6 horas
- **Estado**: ⏳ No Iniciado
- **Descripción**: Mejorar rendimiento con operaciones asincrónicas

Cambios necesarios:
```csharp
// Antes
public List<Orders> Obtener() { }

// Después
public async Task<List<Orders>> ObtenerAsync() { }

// En Controller
var orders = await ordersDAO.ObtenerAsync();
```

---

### 11. Validación de Entrada
- **Ubicación**: Modelos y Controladores
- **Herramientas**: Data Annotations o FluentValidation
- **Esfuerzo**: 2-3 horas
- **Estado**: ⏳ No Iniciado

Ejemplo:
```csharp
public class Orders
{
    [Required(ErrorMessage = "El ID es obligatorio")]
    [Range(1, int.MaxValue)]
    public int OrderID { get; set; }
    
    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime OrderDate { get; set; }
    
    [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string ShipName { get; set; }
}
```

---

### 12. Tests Unitarios
- **Framework**: xUnit o NUnit
- **Ubicación**: Crear carpeta `Tests`
- **Esfuerzo**: 8+ horas
- **Estado**: ⏳ No Iniciado
- **Cobertura Objetivo**: 70%+

Archivos a crear:
```
Tests/
├── OrdersDAOTests.cs
├── OrdersControllerTests.cs
├── CustomersDAOTests.cs
└── CustomersControllerTests.cs
```

Ejemplo:
```csharp
[Fact]
public void ObtenerPedidos_DebeRetornarLista()
{
    // Arrange
    var dao = new OrdersDAO();
    
    // Act
    var result = dao.Obtener();
    
    // Assert
    Assert.NotNull(result);
    Assert.NotEmpty(result);
}
```

---

### 13. Mejorar UI/UX
- **Ubicación**: Views
- **Tareas**:
  - [ ] Actualizar bootstrap a versión más reciente
  - [ ] Mejorar responsividad para móviles
  - [ ] Agregar confirmar eliminación (modal)
  - [ ] Agregar validación cliente-lado
  - [ ] Mejorar iconografía
- **Esfuerzo**: 3-4 horas
- **Estado**: ⏳ No Iniciado

---

## 🔵 BAJO - Mejoras a largo plazo

### 14. Migración a .NET Core / .NET 6+
- **Esfuerzo**: 20-30 horas
- **Estado**: 📋 En Backlog
- **Descripción**: Modernizar framework

Pasos principales:
1. [ ] Crear nuevo proyecto .NET 6
2. [ ] Migrar modelos
3. [ ] Reemplazar ADO.NET con EF Core
4. [ ] Reemplazar MVC con ASP.NET Core Web API
5. [ ] Testing

---

### 15. Implementar Entity Framework Core
- **Reemplaza**: ADO.NET raw SQL
- **Ventajas**: LINQ, menos boilerplate, migrations
- **Esfuerzo**: 8-10 horas
- **Estado**: 📋 En Backlog

Ejemplo EF Core:
```csharp
var orders = await _context.Orders
    .Where(o => o.OrderID == id)
    .Include(o => o.OrderDetails)
    .FirstOrDefaultAsync();
```

---

### 16. Crear API REST
- **Reemplaza**: MVC Views (en parte)
- **Framework**: ASP.NET Core Web API
- **Esfuerzo**: 12-15 horas
- **Estado**: 📋 En Backlog

Endpoints:
```
GET    /api/orders              - Listar pedidos
POST   /api/orders              - Crear pedido
GET    /api/orders/{id}         - Obtener pedido
PUT    /api/orders/{id}         - Actualizar pedido
DELETE /api/orders/{id}         - Eliminar pedido
```

---

### 17. Frontend Moderno
- **Opciones**: React, Vue, Angular
- **Esfuerzo**: 20+ horas
- **Estado**: 📋 En Backlog
- **Descripción**: Reemplazar Razor Views

Stack sugerido:
- React 18
- TypeScript
- Axios/Fetch para API
- Material-UI o Tailwind

---

### 18. Docker & CI/CD
- **Esfuerzo**: 4-6 horas
- **Estado**: 📋 En Backlog

Tareas:
1. [ ] Crear Dockerfile
2. [ ] Crear docker-compose.yml
3. [ ] Configurar GitHub Actions
4. [ ] Automated tests en CI
5. [ ] Automated deployment

---

## 📊 Resumen de Tareas

| # | Tarea | Prioridad | Esfuerzo | Estado |
|---|-------|-----------|----------|--------|
| 1 | Validación NULL | 🔴 Crítica | ⚡ 30min | ⏳ |
| 2 | Manejo Excepciones | 🔴 Crítica | ⏱️ 1-2h | ⏳ |
| 3 | Using Statements | 🔴 Crítica | ⏱️ 2-3h | ⏳ |
| 4 | Paginación | 🔴 Crítica | ⚡ 15min | ⏳ |
| 5 | CRUD Registrar | 🟡 Alta | ⏱️ 1-2h | ⏳ |
| 6 | CRUD Actualizar | 🟡 Alta | ⏱️ 1-2h | ⏳ |
| 7 | CRUD Eliminar | 🟡 Alta | ⏱️ 1h | ⏳ |
| 8 | Logging | 🟡 Alta | ⏱️ 1-2h | ⏳ |
| 9 | Autenticación | 🟢 Media | ⏱️ 3-4h | 📋 |
| 10 | Async/Await | 🟢 Media | ⏱️ 4-6h | 📋 |
| 11 | Validación | 🟢 Media | ⏱️ 2-3h | 📋 |
| 12 | Tests | 🟢 Media | ⏱️ 8+h | 📋 |
| 13 | UI/UX | 🟢 Media | ⏱️ 3-4h | 📋 |
| 14 | .NET Core | 🔵 Baja | ⏱️ 20-30h | 📋 |
| 15 | EF Core | 🔵 Baja | ⏱️ 8-10h | 📋 |
| 16 | API REST | 🔵 Baja | ⏱️ 12-15h | 📋 |
| 17 | Frontend | 🔵 Baja | ⏱️ 20+h | 📋 |
| 18 | Docker/CI-CD | 🔵 Baja | ⏱️ 4-6h | 📋 |

**Total Esfuerzo Crítico**: ~6-7 horas ⏰
**Total Esfuerzo Alto**: ~8-9 horas ⏰
**Total Esfuerzo Medio**: ~21-27 horas ⏰
**Total Esfuerzo Bajo**: ~70+ horas ⏰

---

## 🎯 Sprints Sugeridos

### Sprint 1 (Semana 1) - ESTABILIDAD
```
Meta: Hacer la app estable y sin crashes

Lunes-Martes:
- Validación NULL
- Manejo excepciones

Miércoles-Jueves:
- Using statements
- Corrección paginación

Viernes:
- Testing manual
- Documentación
```

### Sprint 2 (Semana 2) - FUNCIONALIDAD
```
Meta: Implementar CRUD completo

Lunes-Martes:
- CRUD Registrar

Miércoles:
- CRUD Actualizar

Jueves:
- CRUD Eliminar

Viernes:
- Testing
- Documentación
```

### Sprint 3 (Semana 3) - CALIDAD
```
Meta: Agregar logging, validación y tests

Lunes-Martes:
- Logging básico
- Validación entrada

Miércoles-Jueves:
- Tests unitarios

Viernes:
- Revisión código
- Documentación
```

---

## 🔄 Proceso de Verificación

Para cada tarea completada:

- [ ] Código compilado sin errores
- [ ] Funcionalidad probada manualmente
- [ ] Sin nuevas excepciones
- [ ] Documentación actualizada
- [ ] Git commit con mensaje descriptivo
- [ ] Push a rama feature
- [ ] Pull request creado
- [ ] Code review completado
- [ ] Merge a master

---

## 📝 Notas

- **Desarrollador**: [@antwny](https://github.com/antwny)
- **Repositorio**: https://github.com/antwny/northwind-app
- **Rama Principal**: master
- **Rama Desarrollo**: develop

---

**Última actualización**: 2024
**Mantenedor**: [@antwny](https://github.com/antwny)

---

¿Necesitas ayuda? Abre un Issue en GitHub 👉 [Issues](https://github.com/antwny/northwind-app/issues)
