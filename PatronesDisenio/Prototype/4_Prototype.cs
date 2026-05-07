using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDonacion.PatronesDisenio
{
    /// <summary>
    /// Patrón Prototype
    /// Crea nuevos objetos clonando un objeto existente.
    /// </summary>

    public class Reporte : ICloneable
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Formato { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<string> Datos { get; set; }

        public Reporte()
        {
            Datos = new List<string>();
            FechaCreacion = DateTime.Now;
        }

        // Implementar clon superficial
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        // Implementar clon profundo
        public Reporte ClonarProfundo()
        {
            var clon = new Reporte
            {
                Titulo = this.Titulo,
                Contenido = this.Contenido,
                Formato = this.Formato,
                FechaCreacion = this.FechaCreacion,
                Datos = new List<string>(this.Datos) // Copia profunda de la lista
            };
            return clon;
        }

        public override string ToString()
        {
            return $"Reporte - Título: {Titulo}, Formato: {Formato}, Datos: {Datos.Count} registros, Fecha: {FechaCreacion:yyyy-MM-dd HH:mm:ss}";
        }
    }

    // Ejemplo de uso
    public class EjemploPrototype
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Prototype ===\n");

            // Crear reporte original
            var reporteOriginal = new Reporte
            {
                Titulo = "Reporte Mensual",
                Contenido = "Datos importantes del mes",
                Formato = "PDF"
            };
            reporteOriginal.Datos.Add("Dato 1");
            reporteOriginal.Datos.Add("Dato 2");

            Console.WriteLine("Reporte Original:");
            Console.WriteLine(reporteOriginal);

            // Clonar el reporte usando clon profundo
            var reporteClonado = reporteOriginal.ClonarProfundo();
            reporteClonado.Titulo = "Reporte Mensual - Copia";
            reporteClonado.Datos.Add("Dato 3");

            Console.WriteLine("\nReporte Clonado (modificado):");
            Console.WriteLine(reporteClonado);

            Console.WriteLine("\nReporte Original (sin cambios):");
            Console.WriteLine(reporteOriginal);

            Console.WriteLine();
        }
    }
}

