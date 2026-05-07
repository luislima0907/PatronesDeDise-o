using System;

namespace SistemaDonacion.PatronesDisenio
{
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

    // Ejemplo de uso
    public class EjemploAbstractFactory
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Abstract Factory ===\n");

            // Crear componentes con tema claro
            Console.WriteLine("--- Tema Claro ---");
            IFabricaUI fabricaClara = new FabricaUITemaClaro();
            var botonClaro = fabricaClara.CrearBoton();
            var checkboxClaro = fabricaClara.CrearCheckbox();
            botonClaro.Renderizar();
            checkboxClaro.Renderizar();

            Console.WriteLine("\n--- Tema Oscuro ---");
            // Crear componentes con tema oscuro
            IFabricaUI fabricaOscura = new FabricaUITemaOscuro();
            var botonOscuro = fabricaOscura.CrearBoton();
            var checkboxOscuro = fabricaOscura.CrearCheckbox();
            botonOscuro.Renderizar();
            checkboxOscuro.Renderizar();

            Console.WriteLine();
        }
    }
}

