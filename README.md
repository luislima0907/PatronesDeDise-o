# Luis Carlos Lima Pérez 0907-23-20758
 
- --

# Sistema de Donación de Órganos

## Descripción General
Sistema web desarrollado en ASP.NET Core que gestiona el proceso completo de donación y asignación de órganos entre hospitales, pacientes y donantes. Implementa autenticación, control de roles y un sistema de auditoría completo.

---

# Investigación: Patrones de Diseño

---

### 1. Factory Method

El patrón Factory Method sirve para crear objetos sin tener que indicar directamente qué clase se va a usar. En vez de crear los objetos manualmente con el constructor, se utiliza una clase encargada de hacerlo. De esa manera, si más adelante cambia la forma en que se crean los objetos o se agrega uno nuevo, solo es necesario modificar la fábrica y no todo el código.

Por ejemplo, si se trabaja con una imprenta que genera archivos en distintos formatos como PDF, Word o Excel, no es necesario crear cada tipo de documento por separado desde el cliente. Simplemente se solicita el documento y la fábrica se encarga de devolver el formato correcto según lo que se necesite.

 **Implementación:** [PatronesDisenio/FactoryMethod/1_FactoryMethod.cs](SistemaDonacion/PatronesDisenio/FactoryMethod/1_FactoryMethod.cs)

**Conceptos clave**

* **Desacoplamiento:** no hace falta conocer las clases concretas, solo cómo utilizarlas.
* **Centralización:** la creación de objetos queda organizada en un solo lugar.
* **Flexibilidad:** agregar nuevos tipos de objetos resulta más sencillo sin afectar el resto del programa.

### Ejemplo en C#
```csharp
// Interfaz base para los documentos
public interface IDocumento
{
    string Generar();
}

// Implementación concreta: PDF
public class DocumentoPDF : IDocumento
{
    public string Generar()
    {
        return "Documento en formato PDF generado";
    }
}

// Implementación concreta: Word
public class DocumentoWord : IDocumento
{
    public string Generar()
    {
        return "Documento en formato Word generado";
    }
}

// Factory Method: Clase responsable de crear documentos
public class FabricaDocumentos
{
    public IDocumento Crear(string tipo)
    {
        return tipo.ToLower() switch
        {
            "pdf" => new DocumentoPDF(),
            "word" => new DocumentoWord(),
            "excel" => new DocumentoExcel(),
            _ => throw new ArgumentException($"Tipo no soportado: {tipo}")
        };
    }
}

// Uso
var fabrica = new FabricaDocumentos();
var docPDF = fabrica.Crear("pdf");
Console.WriteLine(docPDF.Generar());
```

---

### 2. Abstract Factory

El patrón Abstract Factory es una extensión del Factory Method. La diferencia es que aquí no se crea un solo objeto, sino un conjunto de objetos que tienen relación entre sí. Se utiliza cuando varios elementos deben funcionar en conjunto y mantener el mismo estilo o compatibilidad.

Un ejemplo común es una aplicación con diferentes temas visuales, como modo claro y modo oscuro. Cada tema necesita sus propios botones, ventanas, menús y demás componentes. Con Abstract Factory se pueden crear todos esos elementos relacionados desde una misma fábrica, asegurando que pertenezcan al mismo tema y mantengan coherencia visual.

 **Implementación:** [PatronesDisenio/AbstractFactory/2_AbstractFactory.cs](SistemaDonacion/PatronesDisenio/AbstractFactory/2_AbstractFactory.cs)

**Conceptos clave**

* **Familias de productos:** permite crear varios objetos relacionados entre sí.
* **Consistencia:** asegura que todos los componentes funcionen y combinen correctamente.
* **Variabilidad:** facilita cambiar entre diferentes conjuntos de productos sin modificar gran parte del código.

### Ejemplo en c#
```csharp
// Interfaces para los componentes UI
public interface IBoton
{
    void Renderizar();
}

public interface ICheckbox
{
    void Renderizar();
}

// Implementaciones tema claro
public class BotonTemaClaro : IBoton
{
    public void Renderizar()
    {
        Console.WriteLine("Renderizando Botón con tema claro (fondo blanco, texto negro)");
    }
}

public class CheckboxTemaClaro : ICheckbox
{
    public void Renderizar()
    {
        Console.WriteLine("Renderizando Checkbox con tema claro (casilla blanca)");
    }
}

// Implementaciones tema oscuro
public class BotonTemaOscuro : IBoton
{
    public void Renderizar()
    {
        Console.WriteLine("Renderizando Botón con tema oscuro (fondo negro, texto blanco)");
    }
}

public class CheckboxTemaOscuro : ICheckbox
{
    public void Renderizar()
    {
        Console.WriteLine("Renderizando Checkbox con tema oscuro (casilla negra)");
    }
}

// Abstract Factory
public interface IFabricaUI
{
    IBoton CrearBoton();
    ICheckbox CrearCheckbox();
}

public class FabricaUITemaClaro : IFabricaUI
{
    public IBoton CrearBoton() => new BotonTemaClaro();
    public ICheckbox CrearCheckbox() => new CheckboxTemaClaro();
}

public class FabricaUITemaOscuro : IFabricaUI
{
    public IBoton CrearBoton() => new BotonTemaOscuro();
    public ICheckbox CrearCheckbox() => new CheckboxTemaOscuro();
}

// Uso
IFabricaUI fabricaClara = new FabricaUITemaClaro();
var botonClaro = fabricaClara.CrearBoton();
var checkboxClaro = fabricaClara.CrearCheckbox();
botonClaro.Renderizar();
checkboxClaro.Renderizar();
```

---

### 3. Builder

El patrón Builder se utiliza para crear objetos complejos de forma ordenada y paso a paso. En lugar de usar constructores con demasiados parámetros, se van agregando las propiedades poco a poco hasta completar el objeto. Esto hace que el código sea más claro y fácil de entender.

Se puede comparar con la construcción de una casa. Primero se hacen los cimientos, luego las paredes, después el techo y así sucesivamente. Con Builder ocurre algo parecido: el objeto se arma por partes hasta quedar completo.

 **Implementación:** [PatronesDisenio/Builder/3_Builder.cs](SistemaDonacion/PatronesDisenio/Builder/3_Builder.cs)

**Conceptos clave**

* **Legibilidad:** el código se entiende mejor que usando constructores con muchos parámetros.
* **Flexibilidad:** permite crear objetos solo con las propiedades que realmente se necesitan.
* **Mantenibilidad:** agregar nuevas propiedades o cambios resulta más sencillo.

### Ejemplo en C#
```csharp
public class Usuario
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public int Edad { get; set; }
    public string Rol { get; set; }
}

public class ConstructorUsuario
{
    private Usuario _usuario = new Usuario();

    public ConstructorUsuario ConNombre(string nombre)
    {
        _usuario.Nombre = nombre;
        return this;
    }

    public ConstructorUsuario ConEmail(string email)
    {
        _usuario.Email = email;
        return this;
    }

    public ConstructorUsuario ConEdad(int edad)
    {
        _usuario.Edad = edad;
        return this;
    }

    public ConstructorUsuario ConRol(string rol)
    {
        _usuario.Rol = rol;
        return this;
    }

    public Usuario Construir()
    {
        return _usuario;
    }
}

// Uso - Mucho más legible que pasar 10 parámetros
var usuario = new ConstructorUsuario()
    .ConNombre("Juan Pérez")
    .ConEmail("juan@example.com")
    .ConEdad(30)
    .ConRol("Médico")
    .Construir();
```

---

### 4. Prototype

El patrón Prototype sirve para crear nuevos objetos a partir de la copia de otro objeto ya existente, en lugar de construirlos desde cero. Esto resulta útil cuando crear un objeto requiere mucho tiempo, recursos o configuraciones complejas.

Un ejemplo sería al momento de trabajar con un documento que ya tiene formato, estilos y estructura definidos. En vez de volver a hacerlo todo desde el inicio, simplemente se hace una copia y se modifican únicamente los datos necesarios. Así el proceso se vuelve más rápido y práctico.

 **Implementación:** [PatronesDisenio/Prototype/4_Prototype.cs](SistemaDonacion/PatronesDisenio/Prototype/4_Prototype.cs)

**Conceptos clave**

* **Rendimiento:** evita repetir procesos de creación o configuración que consumen recursos.
* **Clonación:** los objetos pueden generar copias de sí mismos.
* **Velocidad:** copiar un objeto suele ser más rápido que crear uno completamente nuevo.

### Ejemplo en C#
```csharp
public class Reporte : ICloneable
{
    public string Titulo { get; set; }
    public string Contenido { get; set; }
    public string Formato { get; set; }
    public List<string> Datos { get; set; }

    public Reporte()
    {
        Datos = new List<string>();
    }

    // Clon profundo
    public Reporte ClonarProfundo()
    {
        var clon = new Reporte
        {
            Titulo = this.Titulo,
            Contenido = this.Contenido,
            Formato = this.Formato,
            Datos = new List<string>(this.Datos) // Copia profunda
        };
        return clon;
    }
}

// Uso
var reporteOriginal = new Reporte
{
    Titulo = "Reporte Mensual",
    Contenido = "Datos importantes",
    Formato = "PDF"
};
reporteOriginal.Datos.Add("Dato 1");

// Crear copia sin duplicar trabajo de inicialización
var reporteClonado = reporteOriginal.ClonarProfundo();
reporteClonado.Titulo = "Reporte Mensual - Copia";
reporteClonado.Datos.Add("Dato 2");

// El original no se modificó
Console.WriteLine(reporteOriginal.Datos.Count); // 1
Console.WriteLine(reporteClonado.Datos.Count);   // 2
```

---

### 5. Singleton

El patrón Singleton se utiliza cuando se necesita que una clase tenga una sola instancia durante toda la ejecución de la aplicación. Además, permite acceder a esa instancia desde cualquier parte del programa sin tener que crear nuevos objetos constantemente.

Este patrón suele aplicarse en casos donde solo debe existir un recurso compartido, como una conexión a base de datos, una configuración global o un administrador de sesiones. La idea es evitar duplicados innecesarios y mantener todo centralizado en un único objeto.

 **Implementación:** [PatronesDisenio/Singleton/5_Singleton.cs](SistemaDonacion/PatronesDisenio/Singleton/5_Singleton.cs)

**Conceptos clave**

* **Unicidad:** asegura que únicamente exista una instancia de la clase.
* **Acceso global:** permite utilizar la misma instancia desde cualquier parte del código.
* **Control centralizado:** facilita la administración de recursos compartidos o únicos.

### Ejemplo en C#
```csharp
public class ManagerConfiguracion
{
    private static ManagerConfiguracion _instancia;
    private static readonly object _lock = new object();

    private string _urlApiBase;
    private string _usuarioBD;

    // Constructor privado para evitar instanciación directa
    private ManagerConfiguracion()
    {
        _urlApiBase = "https://api.sistemadonacion.com";
        _usuarioBD = "admin";
    }

    // Método thread-safe para obtener la única instancia
    public static ManagerConfiguracion ObtenerInstancia()
    {
        if (_instancia == null)
        {
            lock (_lock)
            {
                if (_instancia == null)
                {
                    _instancia = new ManagerConfiguracion();
                }
            }
        }
        return _instancia;
    }

    public string ObtenerUrlApi() => _urlApiBase;
}

// Uso
var config1 = ManagerConfiguracion.ObtenerInstancia();
var config2 = ManagerConfiguracion.ObtenerInstancia();

// Ambas variables apuntan a la MISMA instancia
Console.WriteLine(ReferenceEquals(config1, config2)); // true
```

---

### 6. Adapter

El patrón Adapter se utiliza para lograr que dos clases con interfaces diferentes puedan trabajar juntas. Funciona como un intermediario que traduce las llamadas de una interfaz a otra, de manera similar a un adaptador de corriente que permite conectar dispositivos incompatibles.

Por ejemplo, puede suceder que exista una librería que cumple exactamente con lo que se necesita, pero sus métodos o estructura no coinciden con el resto del sistema. En ese caso, el Adapter se encarga de conectar ambas partes sin tener que modificar el código original.

 **Implementación:** [PatronesDisenio/Adapter/6_Adapter.cs](SistemaDonacion/PatronesDisenio/Adapter/6_Adapter.cs)

**Conceptos clave**

* **Compatibilidad:** permite integrar clases o sistemas que originalmente no son compatibles.
* **Reutilización:** ayuda a aprovechar código ya existente sin rehacerlo.
* **Traducción:** convierte una interfaz en otra para que puedan comunicarse correctamente.

### Ejemplo en C#
```csharp
// Interfaz que espera la aplicacion
public interface IServicioPago
{
    void ProcesarPago(decimal monto, string descripcion);
}

// API externa de PayPal con interfaz diferente
public class PayPalAPI
{
    public void EnviarDinero(decimal cantidad, string correo, string concepto)
    {
        Console.WriteLine($"PayPal: Enviando ${cantidad} a {correo}");
    }
}

// API externa de Stripe
public class StripeAPI
{
    public void CargarTarjeta(decimal importe, string idTarjeta, string descripcion)
    {
        Console.WriteLine($"Stripe: Cargando ${importe} a tarjeta {idTarjeta}");
    }
}

// Adapter para PayPal
public class AdaptadorPayPal : IServicioPago
{
    private PayPalAPI _paypal = new PayPalAPI();
    private string _correoEmpresa = "empresa@sistemadonacion.com";

    public void ProcesarPago(decimal monto, string descripcion)
    {
        _paypal.EnviarDinero(monto, _correoEmpresa, descripcion);
    }
}

// Adapter para Stripe
public class AdaptadorStripe : IServicioPago
{
    private StripeAPI _stripe = new StripeAPI();
    private string _idTarjeta = "4532-XXXX-XXXX-1234";

    public void ProcesarPago(decimal monto, string descripcion)
    {
        _stripe.CargarTarjeta(monto, _idTarjeta, descripcion);
    }
}

// Uso - El cliente nunca cambia
IServicioPago procesador = new AdaptadorPayPal();
procesador.ProcesarPago(100m, "Donacion");

// Cambiar de proveedor es tan facil como cambiar el adaptador
procesador = new AdaptadorStripe();
procesador.ProcesarPago(100m, "Donacion");
```

---

### 7. Bridge

El patrón Bridge sirve para separar una abstracción de su implementación, permitiendo que ambas puedan cambiar de forma independiente. Esto ayuda a mantener el código más organizado y evita crear demasiadas clases innecesarias.

Un ejemplo sencillo sería trabajar con distintos tipos de vehículos y motores. Si no se usa este patrón, habría que crear una clase para cada combinación posible, como AutoEléctrico, AutoGasolina, MotoEléctrica o MotoGasolina. Con Bridge, el vehículo y el motor se manejan por separado y luego se combinan según lo que se necesite.

 **Implementación:** [PatronesDisenio/Bridge/7_Bridge.cs](SistemaDonacion/PatronesDisenio/Bridge/7_Bridge.cs)

**Conceptos clave**

* **Separación:** divide la abstracción y la implementación para manejarlas de forma independiente.
* **Flexibilidad:** permite cambiar implementaciones sin afectar el resto del sistema.
* **Evita explosión de clases:** reduce la cantidad de clases necesarias para manejar diferentes combinaciones.

### Ejemplo en C#
```csharp
// Implementación: Estrategias de verificación
public interface IVerificadorAcceso
{
    bool Verificar(string usuario, string permiso);
}

public class VerificadorPorRol : IVerificadorAcceso
{
    public bool Verificar(string usuario, string permiso)
    {
        Console.WriteLine($"Verificando permiso '{permiso}' por ROL");
        return true;
    }
}

public class VerificadorPorPermiso : IVerificadorAcceso
{
    public bool Verificar(string usuario, string permiso)
    {
        Console.WriteLine($"Verificando permiso específico '{permiso}'");
        return true;
    }
}

// Abstracción: Recursos
public abstract class Recurso
{
    protected IVerificadorAcceso _verificador;
    protected string _nombre;

    public Recurso(string nombre, IVerificadorAcceso verificador)
    {
        _nombre = nombre;
        _verificador = verificador;
    }

    public abstract void Acceder(string usuario);
}

public class ReporteDashboard : Recurso
{
    public ReporteDashboard(IVerificadorAcceso verificador) 
        : base("Dashboard", verificador) { }

    public override void Acceder(string usuario)
    {
        if (_verificador.Verificar(usuario, "DashboardAccess"))
            Console.WriteLine($"✓ Acceso concedido a {_nombre}");
    }
}

// Uso - Combinaciones dinámicas
var dashboard1 = new ReporteDashboard(new VerificadorPorRol());
dashboard1.Acceder("juan");

var dashboard2 = new ReporteDashboard(new VerificadorPorPermiso());
dashboard2.Acceder("maria");
```

---

### 8. Composite

El patrón Composite permite organizar objetos en estructuras jerárquicas, donde un elemento puede contener otros elementos dentro de él. La ventaja es que tanto los objetos individuales como los grupos de objetos pueden utilizarse de la misma forma.

Un ejemplo común son los menús de una aplicación. Un menú puede contener opciones simples, como “Archivo”, pero también submenús con más opciones dentro. Gracias a este patrón, todos los elementos se manejan de manera uniforme sin importar si son simples o compuestos.

 **Implementación:** [PatronesDisenio/Composite/8_Composite.cs](SistemaDonacion/PatronesDisenio/Composite/8_Composite.cs)

**Conceptos clave**

* **Jerarquía:** ayuda a representar relaciones de tipo parte-todo dentro de una estructura.
* **Tratamiento uniforme:** los objetos simples y los compuestos se utilizan de la misma manera.
* **Recursión:** las operaciones pueden aplicarse a toda la estructura de forma automática.

### Ejemplo en C#
```csharp
// Interfaz componente
public interface IComponenteHospital
{
    string ObtenerNombre();
    List<Medico> ObtenerMedicos();
    void MostrarEstructura(string indentacion = "");
}

// Elemento simple: Médico
public class Medico : IComponenteHospital
{
    public string Nombre { get; set; }
    public string Especialidad { get; set; }

    public Medico(string nombre, string especialidad)
    {
        Nombre = nombre;
        Especialidad = especialidad;
    }

    public string ObtenerNombre() => Nombre;

    public List<Medico> ObtenerMedicos() => new List<Medico> { this };

    public void MostrarEstructura(string indentacion = "")
    {
        Console.WriteLine($"{indentacion} Médico: {Nombre} ({Especialidad})");
    }
}

// Elemento compuesto: Sección
public class Seccion : IComponenteHospital
{
    public string Nombre { get; set; }
    private List<IComponenteHospital> _componentes = new List<IComponenteHospital>();

    public Seccion(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregarComponente(IComponenteHospital componente)
    {
        _componentes.Add(componente);
    }

    public string ObtenerNombre() => Nombre;

    public List<Medico> ObtenerMedicos()
    {
        var medicos = new List<Medico>();
        foreach (var componente in _componentes)
        {
            medicos.AddRange(componente.ObtenerMedicos());
        }
        return medicos;
    }

    public void MostrarEstructura(string indentacion = "")
    {
        Console.WriteLine($"{indentacion}Seccion: {Nombre}");
        foreach (var componente in _componentes)
        {
            componente.MostrarEstructura(indentacion + "  ");
        }
    }
}

// Elemento compuesto: Departamento
public class Departamento : IComponenteHospital
{
    public string Nombre { get; set; }
    private List<IComponenteHospital> _componentes = new List<IComponenteHospital>();

    public Departamento(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregarComponente(IComponenteHospital componente)
    {
        _componentes.Add(componente);
    }

    public string ObtenerNombre() => Nombre;

    public List<Medico> ObtenerMedicos()
    {
        var medicos = new List<Medico>();
        foreach (var componente in _componentes)
        {
            medicos.AddRange(componente.ObtenerMedicos());
        }
        return medicos;
    }

    public void MostrarEstructura(string indentacion = "")
    {
        Console.WriteLine($"{indentacion} Departamento: {Nombre}");
        foreach (var componente in _componentes)
        {
            componente.MostrarEstructura(indentacion + "  ");
        }
    }
}

// Elemento compuesto: Hospital
public class Hospital : IComponenteHospital
{
    public string Nombre { get; set; }
    private List<IComponenteHospital> _componentes = new List<IComponenteHospital>();

    public Hospital(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregarComponente(IComponenteHospital componente)
    {
        _componentes.Add(componente);
    }

    public string ObtenerNombre() => Nombre;

    public List<Medico> ObtenerMedicos()
    {
        var medicos = new List<Medico>();
        foreach (var componente in _componentes)
        {
            medicos.AddRange(componente.ObtenerMedicos());
        }
        return medicos;
    }

    public void MostrarEstructura(string indentacion = "")
    {
        Console.WriteLine($"{indentacion}Hospital: {Nombre}");
        foreach (var componente in _componentes)
        {
            componente.MostrarEstructura(indentacion + "  ");
        }
    }
}

// Uso
var hospital = new Hospital("Hospital Central San José");
var deptCirugia = new Departamento("Cirugía");
var seccionCiugiaGeneral = new Seccion("Cirugía General");

seccionCiugiaGeneral.AgregarComponente(new Medico("Dr. García López", "Cirujano General"));
seccionCiugiaGeneral.AgregarComponente(new Medico("Dra. López Martínez", "Cirujana General"));

deptCirugia.AgregarComponente(seccionCiugiaGeneral);
hospital.AgregarComponente(deptCirugia);

// Obtener todos los médicos de forma uniforme
var todosMedicos = hospital.ObtenerMedicos();
Console.WriteLine($"Total de médicos: {todosMedicos.Count}");

// Mostrar estructura jerárquica
hospital.MostrarEstructura();
```

---

# Implementación de Patrones de Diseño

## Patrón Implementado: Builder

El patrón Builder se implementó porque el sistema tiene búsquedas avanzadas con múltiples criterios opcionales en la bitácora. Sin Builder, se necesitarían muchos parámetros opcionales que hacen el código difícil de leer y mantener.

### Dónde Se Aplica

- Archivo creado: `DTOs/CriterioBusquedaBitacoraDto.cs`
- Archivo modificado: `Controllers/BitacoraController.cs`

Método nuevo: `BuscarAvanzado()` en BitacoraController

### Problema Sin Builder

```csharp
public IActionResult ObtenerBitacora(
    string usuario = null,
    string accion = null,
    DateTime? fechaInicio = null,
    DateTime? fechaFin = null,
    string tabla = null,
    int? registroId = null,
    int? pagina = null,
    int? tamanioPagina = null)
{
    // Muchos parámetros opcionales
}
```

### Solución Con Builder

```csharp
var criterios = CriterioBusquedaBitacoraDto.Construir
    .PorUsuario(5)
    .PorTabla("Paciente")
    .EnRangoDeFechas(inicio, fin)
    .ConPaginacion(1, 10)
    .Construir();
```

### Ejemplo de Uso

**API:** `GET /api/bitacora/buscar-avanzado?usuarioId=3&tabla=Donante&accion=Registrar&pagina=1&tamanioPagina=20`

El método `BuscarAvanzado` construye automáticamente los criterios usando el Builder:

```csharp
var criterios = CriterioBusquedaBitacoraDto.Construir
    .ConPaginacion(pagina, tamanioPagina);

if (usuarioId.HasValue)
    criterios = criterios.PorUsuario(usuarioId.Value);

if (!string.IsNullOrEmpty(tabla))
    criterios = criterios.PorTabla(tabla);

if (!string.IsNullOrEmpty(accion))
    criterios = criterios.PorAccion(accion);

var criterioBusqueda = criterios.Construir();
```

### Segmentos del Proyecto Beneficiados

1. **BitacoraController.BuscarAvanzado()**: Búsquedas avanzadas con múltiples filtros
2. **PacienteController**: Podría usar Builder para búsquedas complejas de pacientes
3. **DonanteController**: Búsquedas avanzadas de donantes con criterios opcionales
4. **ReportesController**: Construcción de reportes con múltiples parámetros

### Cambios Realizados

1. Creado `DTOs/CriterioBusquedaBitacoraDto.cs` con:
    - Clase `CriterioBusquedaBitacoraDto` (DTO)
    - Clase `ConstructorBusquedaBitacora` (Builder con métodos fluidos)

2. Modificado `Controllers/BitacoraController.cs`:
    - Agregado using: `using SistemaDonacion.DTOs;`
    - Nuevo endpoint: `[HttpGet("buscar-avanzado")] BuscarAvanzado()`
    - Demuestra uso del Builder con parámetros opcionales

### Clases del Builder

**CriterioBusquedaBitacoraDto**: DTO con propiedades opcionales
- UsuarioId, Tabla, Accion, FechaInicio, FechaFin, RegistroId, Pagina, TamanioPagina

**ConstructorBusquedaBitacora**: Builder con métodos:
- PorUsuario(int)
- PorTabla(string)
- PorAccion(string)
- EnRangoDeFechas(DateTime, DateTime)
- Desde(DateTime)
- Hasta(DateTime)
- PorRegistro(int)
- ConPaginacion(int, int)
- Construir()

Cada método retorna `this` para encadenamiento fluido.

