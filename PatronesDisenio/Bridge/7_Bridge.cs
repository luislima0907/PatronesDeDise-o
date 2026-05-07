using System;

namespace SistemaDonacion.PatronesDisenio
{
    /// <summary>
    /// Patrón Bridge
    /// Desvincula la abstracción de su implementación.
    /// </summary>

    // Implementación: Estrategias de verificación
    public interface IVerificadorAcceso
    {
        bool Verificar(string usuario, string permiso);
    }

    public class VerificadorPorRol : IVerificadorAcceso
    {
        public bool Verificar(string usuario, string permiso)
        {
            // Lógica de verificación por rol
            Console.WriteLine($"Verificando permiso '{permiso}' para usuario '{usuario}' por ROL");
            return true;
        }
    }

    public class VerificadorPorPermiso : IVerificadorAcceso
    {
        public bool Verificar(string usuario, string permiso)
        {
            // Lógica de verificación por permisos específicos
            Console.WriteLine($"Verificando permiso específico '{permiso}' para usuario '{usuario}'");
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
            : base("Dashboard", verificador)
        {
        }

        public override void Acceder(string usuario)
        {
            if (_verificador.Verificar(usuario, "DashboardAccess"))
            {
                Console.WriteLine($"✓ Acceso concedido a {_nombre} para {usuario}\n");
            }
            else
            {
                Console.WriteLine($"✗ Acceso denegado a {_nombre} para {usuario}\n");
            }
        }
    }

    public class ReporteFinanciero : Recurso
    {
        public ReporteFinanciero(IVerificadorAcceso verificador) 
            : base("Reporte Financiero", verificador)
        {
        }

        public override void Acceder(string usuario)
        {
            if (_verificador.Verificar(usuario, "FinancialAccess"))
            {
                Console.WriteLine($"✓ Acceso concedido a {_nombre} para {usuario}\n");
            }
            else
            {
                Console.WriteLine($"✗ Acceso denegado a {_nombre} para {usuario}\n");
            }
        }
    }

    // Ejemplo de uso
    public class EjemploBridge
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Bridge ===\n");

            // Dashboard con verificación por rol
            Console.WriteLine("--- Dashboard con verificación por ROL ---");
            Recurso dashboard1 = new ReporteDashboard(new VerificadorPorRol());
            dashboard1.Acceder("juan.admin");

            // Dashboard con verificación por permisos específicos
            Console.WriteLine("--- Dashboard con verificación por PERMISOS ---");
            Recurso dashboard2 = new ReporteDashboard(new VerificadorPorPermiso());
            dashboard2.Acceder("maria.medico");

            // Reporte financiero con verificación por rol
            Console.WriteLine("--- Reporte Financiero con verificación por ROL ---");
            Recurso reporteFinanciero1 = new ReporteFinanciero(new VerificadorPorRol());
            reporteFinanciero1.Acceder("luis.contador");

            // Reporte financiero con verificación por permisos específicos
            Console.WriteLine("--- Reporte Financiero con verificación por PERMISOS ---");
            Recurso reporteFinanciero2 = new ReporteFinanciero(new VerificadorPorPermiso());
            reporteFinanciero2.Acceder("ana.auditor");

            Console.WriteLine();
        }
    }
}

