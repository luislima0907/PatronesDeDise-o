using System;

namespace SistemaDonacion.PatronesDisenio
{
    /// <summary>
    /// Patrón Builder
    /// Construye objetos complejos paso a paso de manera legible.
    /// </summary>

    public class Usuario
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Rol { get; set; }
        public string Telefono { get; set; }

        public override string ToString()
        {
            return $"Usuario: {Nombre}, Email: {Email}, Edad: {Edad}, Rol: {Rol}, Teléfono: {Telefono}";
        }
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

        public ConstructorUsuario ConTelefono(string telefono)
        {
            _usuario.Telefono = telefono;
            return this;
        }

        public Usuario Construir()
        {
            return _usuario;
        }
    }

    // Ejemplo de uso
    public class EjemploBuilder
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Builder ===\n");

            // Crear usuario de forma legible paso a paso
            var usuario1 = new ConstructorUsuario()
                .ConNombre("Juan Pérez")
                .ConEmail("juan@example.com")
                .ConEdad(30)
                .ConRol("Médico")
                .ConTelefono("555-1234")
                .Construir();

            Console.WriteLine("Usuario 1: " + usuario1);

            // Crear otro usuario con menos propiedades
            var usuario2 = new ConstructorUsuario()
                .ConNombre("María García")
                .ConEmail("maria@example.com")
                .ConRol("Administrador")
                .Construir();

            Console.WriteLine("Usuario 2: " + usuario2);

            Console.WriteLine();
        }
    }
}

