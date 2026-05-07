using System;

namespace SistemaDonacion.PatronesDisenio
{
    /// <summary>
    /// Patrón Singleton
    /// Asegura que una clase tenga una única instancia en toda la aplicación.
    /// </summary>

    public class ManagerConfiguracion
    {
        private static ManagerConfiguracion _instancia;
        private static readonly object _lock = new object();

        // Propiedades de configuración
        private string _urlApiBase;
        private string _usuarioBD;
        private int _tiempoExpiracionSesion;

        // Constructor privado para evitar instanciación directa
        private ManagerConfiguracion()
        {
            CargarConfiguracion();
        }

        // Método para obtener la instancia única de forma thread-safe
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

        private void CargarConfiguracion()
        {
            _urlApiBase = "https://api.sistemadonacion.com";
            _usuarioBD = "admin";
            _tiempoExpiracionSesion = 3600; // 1 hora en segundos
        }

        public string ObtenerUrlApi()
        {
            return _urlApiBase;
        }

        public string ObtenerUsuarioBD()
        {
            return _usuarioBD;
        }

        public int ObtenerTiempoExpiracion()
        {
            return _tiempoExpiracionSesion;
        }

        public void MostrarConfiguracion()
        {
            Console.WriteLine($"URL API: {_urlApiBase}");
            Console.WriteLine($"Usuario BD: {_usuarioBD}");
            Console.WriteLine($"Tiempo Expiración: {_tiempoExpiracionSesion} segundos");
        }
    }

    // Ejemplo de uso
    public class EjemploSingleton
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Singleton ===\n");

            // Primera llamada - crea la instancia
            var config1 = ManagerConfiguracion.ObtenerInstancia();
            Console.WriteLine("Primera instancia obtenida:");
            config1.MostrarConfiguracion();

            // Segunda llamada - obtiene la misma instancia
            var config2 = ManagerConfiguracion.ObtenerInstancia();
            Console.WriteLine("\nSegunda instancia obtenida:");
            config2.MostrarConfiguracion();

            // Verificar que es la misma instancia
            Console.WriteLine($"\n¿Son la misma instancia? {ReferenceEquals(config1, config2)}");

            // Tercera llamada - confirma que es la misma
            var config3 = ManagerConfiguracion.ObtenerInstancia();
            Console.WriteLine($"¿config1 y config3 son iguales? {ReferenceEquals(config1, config3)}");

            Console.WriteLine();
        }
    }
}

