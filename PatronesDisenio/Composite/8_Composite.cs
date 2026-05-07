using System;
using System.Collections.Generic;

namespace SistemaDonacion.PatronesDisenio
{
    /// <summary>
    /// Patrón Composite
    /// Compone objetos en estructuras de árbol para representar jerarquías parte-todo.
    /// </summary>

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

        public void RemoverComponente(IComponenteHospital componente)
        {
            _componentes.Remove(componente);
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
            Console.WriteLine($"{indentacion} Sección: {Nombre}");
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

        public void RemoverComponente(IComponenteHospital componente)
        {
            _componentes.Remove(componente);
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

        public void RemoverComponente(IComponenteHospital componente)
        {
            _componentes.Remove(componente);
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
            Console.WriteLine($"{indentacion} Hospital: {Nombre}");
            foreach (var componente in _componentes)
            {
                componente.MostrarEstructura(indentacion + "  ");
            }
        }
    }

    // Ejemplo de uso
    public class EjemploComposite
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Composite ===\n");

            // Crear estructura del hospital
            var hospital = new Hospital("Hospital Central San José");

            // Crear departamento de Cirugía
            var deptCirugia = new Departamento("Cirugía");

            // Crear secciones dentro de Cirugía
            var seccionCiugiaGeneral = new Seccion("Cirugía General");
            seccionCiugiaGeneral.AgregarComponente(new Medico("Dr. García López", "Cirujano General"));
            seccionCiugiaGeneral.AgregarComponente(new Medico("Dra. López Martínez", "Cirujana General"));

            var seccionCirugiaTorax = new Seccion("Cirugía de Tórax");
            seccionCirugiaTorax.AgregarComponente(new Medico("Dr. Hernández Rodríguez", "Cirujano Torácico"));

            deptCirugia.AgregarComponente(seccionCiugiaGeneral);
            deptCirugia.AgregarComponente(seccionCirugiaTorax);

            // Crear departamento de Medicina Interna
            var deptMedicina = new Departamento("Medicina Interna");
            var seccionCardiologia = new Seccion("Cardiología");
            seccionCardiologia.AgregarComponente(new Medico("Dr. Pérez Gómez", "Cardiólogo"));
            seccionCardiologia.AgregarComponente(new Medico("Dra. Sánchez Díaz", "Cardióloga"));

            deptMedicina.AgregarComponente(seccionCardiologia);

            // Agregar departamentos al hospital
            hospital.AgregarComponente(deptCirugia);
            hospital.AgregarComponente(deptMedicina);

            // Mostrar estructura completa
            hospital.MostrarEstructura();

            // Obtener todos los médicos de forma uniforme
            var todosMedicos = hospital.ObtenerMedicos();
            Console.WriteLine($"\n\n Total de médicos en el hospital: {todosMedicos.Count}");
            Console.WriteLine("Listado de médicos:");
            foreach (var medico in todosMedicos)
            {
                Console.WriteLine($"  - {medico.Nombre}");
            }

            // Obtener médicos de un departamento específico
            Console.WriteLine($"\n Total de médicos en Cirugía: {deptCirugia.ObtenerMedicos().Count}");

            Console.WriteLine();
        }
    }
}
