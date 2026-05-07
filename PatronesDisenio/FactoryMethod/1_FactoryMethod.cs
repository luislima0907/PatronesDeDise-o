using System;

namespace SistemaDonacion.PatronesDisenio
{
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

    // Implementación concreta: Excel
    public class DocumentoExcel : IDocumento
    {
        public string Generar()
        {
            return "Documento en formato Excel generado";
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
                _ => throw new ArgumentException($"Tipo de documento no soportado: {tipo}")
            };
        }
    }

    // Ejemplo de uso
    public class EjemploFactoryMethod
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Factory Method ===\n");

            var fabrica = new FabricaDocumentos();

            var docPDF = fabrica.Crear("pdf");
            Console.WriteLine(docPDF.Generar());

            var docWord = fabrica.Crear("word");
            Console.WriteLine(docWord.Generar());

            var docExcel = fabrica.Crear("excel");
            Console.WriteLine(docExcel.Generar());

            Console.WriteLine();
        }
    }
}