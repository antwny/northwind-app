# 🤝 GUÍA DE CONTRIBUCIÓN - NorthwindApp

¡Gracias por tu interés en contribuir a NorthwindApp! Este documento te guiará a través del proceso.

---

## 📋 Índice
1. [Antes de Empezar](#antes-de-empezar)
2. [Reportar Issues](#reportar-issues)
3. [Hacer una Contribución](#hacer-una-contribución)
4. [Estándares de Código](#estándares-de-código)
5. [Process de Pull Request](#proceso-de-pull-request)
6. [Preguntas Frecuentes](#preguntas-frecuentes)

---

## 🎯 Antes de Empezar

### 1. Lee la Documentación
- ✅ [README.md](README.md) - Descripción general
- ✅ [GUIA_RAPIDA.md](GUIA_RAPIDA.md) - Cómo ejecutar
- ✅ [ANALISIS_TECNICO.md](ANALISIS_TECNICO.md) - Arquitectura
- ✅ [TAREAS_PENDIENTES.md](TAREAS_PENDIENTES.md) - Qué hacer

### 2. Configura tu Entorno
```powershell
# Clona el repositorio
git clone https://github.com/antwny/northwind-app.git
cd NorthwindApp

# Crea una rama personal
git checkout -b feature/tu-feature

# Abre en Visual Studio
start NorthwindApp.sln
```

### 3. Entiende la Estructura
```
Controllers → Models → Data → Database
```

Cada capa tiene una responsabilidad específica. No las mezcles.

---

## 🐛 Reportar Issues

### Encontraste un Bug?

**Por favor, antes de abrir un issue:**

1. ✅ Busca si ya existe un issue similar
2. ✅ Comprueba que es realmente un bug
3. ✅ Prepara información de debugging

**Cuando abras el issue, incluye:**

```markdown
## Descripción
[Descripción clara del problema]

## Pasos para Reproducir
1. [Primer paso]
2. [Segundo paso]
3. ...

## Comportamiento Esperado
[Qué debería pasar]

## Comportamiento Actual
[Qué está pasando]

## Información del Entorno
- OS: [Windows/Linux/Mac]
- Visual Studio: [versión]
- .NET Framework: 4.8
- SQL Server: [versión]

## Mensaje de Error
[Si aplica, incluye el stack trace completo]

## Captura de Pantalla
[Si aplica, una captura del error]
```

### Sugerencias de Mejora

Si tienes una idea para mejorar el proyecto:

```markdown
## Descripción de la Mejora
[Descripción clara]

## Caso de Uso
[Por qué es útil]

## Implementación Sugerida
[Si tienes ideas, comparte]

## Alternativas Consideradas
[Otras opciones]
```

---

## 💡 Hacer una Contribución

### Paso 1: Elige una Tarea

**Opciones:**
- 🐛 Corregir un bug ([Issues abiertos](https://github.com/antwny/northwind-app/issues))
- 📋 Trabajar en una tarea de [TAREAS_PENDIENTES.md](TAREAS_PENDIENTES.md)
- 💡 Proponer una mejora nueva

**Busca tareas con labels:**
- `good-first-issue` - Para nuevos contribuyentes
- `help-wanted` - Se necesita ayuda
- `bug` - Corregir un bug
- `enhancement` - Mejora de feature

### Paso 2: Crea una Rama

```powershell
# Para bugs
git checkout -b fix/descripcion-del-bug

# Para features
git checkout -b feature/nombre-del-feature

# Para documentación
git checkout -b docs/nombre-del-documento

# Ejemplos reales
git checkout -b fix/validation-null-shipaddress
git checkout -b feature/implement-order-create
git checkout -b docs/deployment-guide
```

### Paso 3: Haz tus Cambios

**Guías:**
- Haz commits pequeños y focalizados
- Usa mensajes de commit descriptivos
- Prueba tus cambios localmente
- No hagas cambios no relacionados

**Mensajes de Commit Buenos:**
```
fix: validar NULL en ShipAddress
feature: implementar método Registrar() en OrdersDAO
docs: agregar guía de deploymen
refactor: mejorar manejo de excepciones
test: agregar tests para OrdersDAO
```

**Mensajes de Commit Malos:**
```
fixed stuff
updates
asdf
work in progress
```

### Paso 4: Prueba Tus Cambios

```powershell
# Compila
Ctrl+Shift+B

# Prueba manualmente
F5

# Si hay tests
run tests with xUnit or NUnit
```

### Paso 5: Push a tu Rama

```powershell
git add .
git commit -m "descripcion clara del cambio"
git push origin tu-rama
```

---

## 📏 Estándares de Código

### C# - Convenciones

```csharp
// ✅ CORRECTO

namespace NorthwindApp.Data
{
    public class OrdersDAO : IOrders
    {
        private string _connectionString;  // camelCase para privadas
        
        public List<Orders> ObtenerPaginado(int page, int size)  // PascalCase para métodos
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_connectionString))
                {
                    // código
                    return orders;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error obteniendo pedidos", ex);
                throw;
            }
        }
    }
}

// ❌ INCORRECTO

public class OrdersDAO
{
    public String _conStr;  // evita abreviaturas
    
    public list<Orders> obtener_paginado()  // snake_case para métodos
    {
        // sin manejo de excepciones
        return new list<Orders>();  // list en minúscula
    }
}
```

### Formatting

- **Indentación**: 4 espacios
- **Líneas largas**: Máximo 120 caracteres
- **Llaves**: Nueva línea (Allman style)

```csharp
// ✅ CORRECTO
if (condition)
{
    // código
}

// ❌ INCORRECTO
if (condition) { // código }
```

### Comentarios

- Comenta el **WHY**, no el **WHAT**
- Evita comentarios obvios

```csharp
// ✅ CORRECTO
// Validar NULL porque BD puede retornar NULL para campos opcionales
ShipAddress = reader.IsDBNull(4) ? null : reader.GetString(4),

// ❌ INCORRECTO
// Obtener el string del reader
ShipAddress = reader.GetString(4),

// ❌ INCORRECTO
// incrementar i
i++;
```

### Métodos

- **Máximo 30 líneas** por método
- **Un nivel** de abstracción por método
- **Nombres claros**

```csharp
// ✅ CORRECTO
public List<Orders> Obtener()
{
    var orders = new List<Orders>();
    
    try
    {
        using (var conexion = CreateConnection())
        {
            var reader = ExecuteQuery(conexion, query);
            orders = MapReaderToOrders(reader);
        }
    }
    catch (Exception ex)
    {
        HandleError(ex);
    }
    
    return orders;
}

// ❌ INCORRECTO
public List<Orders> GetOrders()
{
    // 100+ líneas de código
    // multiple niveles de abstracción
    // sin manejo de errores
}
```

### Clases y Responsabilidades

- **Una responsabilidad** por clase (SRP)
- **Pequeñas y focalizadas**

```csharp
// ✅ CORRECTO
public class OrdersDAO : IOrders { }      // Solo datos de Orders
public class OrdersValidator { }           // Solo validación de Orders
public class OrdersMapper { }             // Solo mapeo de Orders

// ❌ INCORRECTO
public class OrdersManager                // Hace demasiado
{
    public void GetOrders() { }
    public void ValidateOrders() { }
    public void MapOrders() { }
    public void SendEmail() { }
}
```

### HTML/Razor

```html
<!-- ✅ CORRECTO -->
<div class="table-responsive">
    <table class="table table-striped">
        <thead>
            <tr>
                <th>@Html.DisplayNameFor(m => m.OrderID)</th>
            </tr>
        </thead>
    </table>
</div>

<!-- ❌ INCORRECTO -->
<div>
<table><tr><td><!--content--></td></tr></table>
</div>
```

---

## 📤 Proceso de Pull Request

### 1. Crea el Pull Request

En GitHub, selecciona tu rama y haz click en "New Pull Request"

**Completa el template:**

```markdown
## Descripción
[Qué cambios hiciste y por qué]

## Tipo de Cambio
- [ ] Bug fix
- [ ] Feature nueva
- [ ] Breaking change
- [ ] Documentación

## Testing
- [ ] Probado localmente
- [ ] Sin errores de compilación
- [ ] Tests pasan (si aplica)

## Checklist
- [ ] Código sigue estándares
- [ ] Documentación actualizada
- [ ] Tests agregados/actualizados
- [ ] Commit messages claros
- [ ] Sin cambios no relacionados

## Screenshots (si aplica)
[Incluye capturas de pantalla]

## Links Relacionados
- Closes #123
- Related to #456
```

### 2. Review del Código

Un maintainer revisará tu código y puede:
- ✅ Aprobar (merge)
- 📝 Pedir cambios (con comentarios)
- ❌ Rechazar (con explicación)

**Sé receptivo a feedback:**
- Explica tus decisiones
- Haz cambios solicitados
- Aprende del feedback

### 3. Actualiza tu PR

Si se piden cambios:

```powershell
# Haz los cambios localmente
git add .
git commit -m "Responder feedback: [descripcion]"
git push origin tu-rama

# El PR se actualiza automáticamente
```

### 4. Merge

Una vez aprobado, un maintainer hará merge:

```bash
Squash and merge: Si hay muchos commits
Regular merge: Si los commits son claros
Rebase and merge: Si quieres historia lineal
```

---

## ❓ Preguntas Frecuentes

### ¿Por dónde empiezo?

1. Lee [GUIA_RAPIDA.md](GUIA_RAPIDA.md)
2. Busca issues con label `good-first-issue`
3. Lee [TAREAS_PENDIENTES.md](TAREAS_PENDIENTES.md) y elige una tarea **pequeña**

### ¿Qué si mi feature es grande?

Divídela en commits pequeños:
```
commit 1: base structure
commit 2: implementation part 1
commit 3: implementation part 2
commit 4: tests
commit 5: documentation
```

### ¿Cómo incluyo screenshots?

```markdown
## Screenshot
![Description](path-to-screenshot.png)
```

### ¿Y si quiero trabajar en algo no listado?

1. Abre un issue describiendo tu idea
2. Espera feedback
3. Si es aprobado, crea una rama y trabaja

### ¿Cuánto tiempo para respuesta?

- Issues: 1-2 días laborales
- PRs: 2-3 días laborales
- Merge: Mismo día si está aprobado

### ¿Mi PR fue rechazado. Y ahora?

Es normal. Cada repositorio tiene estándares. Aprende de los comentarios y:
1. Entiende el feedback
2. Pregunta si no entiendes
3. Intenta nuevamente con una nueva PR

---

## 🎓 Recursos de Aprendizaje

### ASP.NET MVC
- [Documentación Oficial](https://docs.microsoft.com/aspnet/mvc)
- [Tutoriales Microsoft](https://docs.microsoft.com/aspnet/mvc/overview/getting-started)

### .NET Framework
- [Documentación .NET Framework 4.8](https://docs.microsoft.com/dotnet/framework)

### SQL Server
- [Documentación SQL Server](https://docs.microsoft.com/sql/)

### Control de Versiones
- [Git Guide](https://rogerdudley.github.io/git-guide/)
- [GitHub Guides](https://guides.github.com/)

### Mejores Prácticas
- [Microsoft Docs - Code Style](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Clean Code](https://www.oreilly.com/library/view/clean-code-a/9780136083238/) (libro recomendado)

---

## 🙏 Agradecimientos

¡Gracias por tu interés en contribuir! Las contribuciones, sin importar el tamaño, son muy valoradas.

Tu trabajo ayuda a:
- ✅ Mejorar la aplicación
- ✅ Ayudar a otros desarrolladores
- ✅ Construir una mejor comunidad

---

## 📞 Contacto

- **Issues**: [GitHub Issues](https://github.com/antwny/northwind-app/issues)
- **Discussions**: [GitHub Discussions](https://github.com/antwny/northwind-app/discussions)
- **Autor**: [@antwny](https://github.com/antwny)

---

**Última actualización**: 2024
**Última revisión**: 2024

**¡Feliz contribuyendo! 🚀**
