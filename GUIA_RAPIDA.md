# 🚀 GUÍA RÁPIDA DE INICIO - NorthwindApp

## ⚡ 5 Minutos para Empezar

### Paso 1: Clonar el Repositorio
```powershell
git clone https://github.com/antwny/northwind-app.git
cd NorthwindApp
```

### Paso 2: Abrir en Visual Studio
```powershell
# Opción A: Desde PowerShell
start NorthwindApp.sln

# Opción B: Abrir manualmente
# Archivo → Abrir → NorthwindApp.sln
```

### Paso 3: Configurar Base de Datos

Edita `Web.config` y busca:
```xml
<connectionStrings>
    <add name="NorthwindContext" 
```

Reemplaza con tu servidor:

**Para LocalDB**:
```xml
<add name="NorthwindContext" 
     connectionString="Server=(localdb)\mssqllocaldb;Database=Northwind;Integrated Security=true;" 
     providerName="System.Data.SqlClient" />
```

**Para SQL Server Express**:
```xml
<add name="NorthwindContext" 
     connectionString="Server=.\SQLEXPRESS;Database=Northwind;Integrated Security=true;" 
     providerName="System.Data.SqlClient" />
```

### Paso 4: Compilar y Ejecutar
```powershell
# En Visual Studio:
# 1. Ctrl + Shift + B   (compilar)
# 2. F5                 (ejecutar)
```

### Paso 5: Acceder a la App
```
http://localhost:PORT/Orders/ListaOrders
```

---

## 📚 Rutas Principales

```
GET  /Orders/ListaOrders              Listado de pedidos (paginado)
POST /Orders/ListaOrders              Buscar pedido por ID
GET  /Orders/DetallesOrders?id=10248  Detalles de pedido
GET  /Customers/Lista                 Listado de clientes
GET  /Customers/Detalles?id=ALFKI     Detalles de cliente
```

---

## 🎓 Estructura Básica para Entender

```
Tu Solicitud (Browser)
        ↓
    Controller (recibe la solicitud, valida)
        ↓
    DAO (obtiene datos de la BD con validación NULL)
        ↓
    Database (Northwind SQL Server)
        ↓
    DAO (retorna resultados validados)
        ↓
    Controller (prepara la vista, ViewBag)
        ↓
    View (Razor) (renderiza HTML Bootstrap)
        ↓
    Browser (muestra la página responsive)
```

---

## 🔧 Troubleshooting Rápido

### ❌ Error: "Server (localdb)\mssqllocaldb not found"
**Solución**: Cambia a SQL Server Express en `Web.config`

### ❌ Error: "Cannot open database 'Northwind'"
**Solución**: 
1. Descarga el script de Northwind
2. Ejecuta: SQL Management Studio → Nuevo query → Ejecuta script

### ❌ Error: "The name 'ViewBag' does not exist"
**Solución**: Asegúrate que la vista hereda de `WebViewPage`

### ❌ Puerto ya está en uso
**Solución**: En `Properties` → Web → Cambiar puerto local

### ✅ Errores de NULL ya resueltos
**Nota**: IsDBNull() está implementado en todos los lectores SQL

---

## 📖 Leer Primero

1. `README.md` - Descripción general
2. `ANALISIS_TECNICO.md` - Problemas y recomendaciones
3. `Controllers/OrdersController.cs` - Lógica principal
4. `Data/OrdersDAO.cs` - Acceso a datos

---

## 🎯 Próximos Pasos Recomendados

### Si quieres aprender:
- [ ] Lee los comentarios del código
- [ ] Sigue el flujo: Controller → DAO → Database
- [ ] Experimenta: Modifica una vista y compila

### Si quieres mejorar:
- [ ] Implementa validación NULL en OrdersDAO
- [ ] Agrega try-catch en métodos
- [ ] Implementa método Registrar() en DAO

### Si quieres modernizar:
- [ ] Migra a .NET Core
- [ ] Usa Entity Framework Core
- [ ] Crea un API REST

---

## 💡 Tips Útiles

### Debugging
```
Visual Studio → Debug → Start Debugging (F5)
Punto de ruptura: Clic en número de línea
Variables: Ver en "Locals" o "Watch"
```

### Modificar Vistas
```
Edita archivos en: Views/Orders/*.cshtml
Compila (Ctrl+Shift+B)
Actualiza browser
```

### Ver Queries SQL
```
En OrdersDAO, agrega: 
Console.WriteLine(sql);  // Ver consulta SQL generada
```

---

## 🆘 Necesitas Ayuda?

1. **Repositorio GitHub**: https://github.com/antwny/northwind-app
2. **Issues**: Abre una "Issue" con tu problema
3. **Wiki**: Busca en la documentación del proyecto
4. **Archivo ANALISIS_TECNICO.md**: Problemas comunes listados

---

## ✅ Checklist de Inicio

- [ ] Cloné el repositorio
- [ ] Abrí NorthwindApp.sln en Visual Studio
- [ ] Edité Web.config con mi servidor
- [ ] Compilé sin errores (Ctrl+Shift+B)
- [ ] Ejecuté la aplicación (F5)
- [ ] Vi la página de listado de pedidos
- [ ] Hice una búsqueda de pedido
- [ ] Vi detalles de un pedido
- [ ] Visité la página de clientes

✨ **¡Felicidades! Ya tienes NorthwindApp ejecutándose correctamente.**

---

## 📚 Recursos Externos

- **ASP.NET MVC**: https://docs.microsoft.com/aspnet/mvc/overview
- **.NET Framework 4.8**: https://docs.microsoft.com/dotnet/framework
- **SQL Server**: https://docs.microsoft.com/sql/
- **Northwind DB**: https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs

---

**Última actualización**: 2024
**Autor**: [@antwny](https://github.com/antwny)
