using System;

namespace SistemaDonacion.PatronesDisenio
{
    /// <summary>
    /// Patrón Adapter
    /// Permite que dos clases con interfaces incompatibles trabajen juntas.
    /// </summary>

    // Interfaz que espera la aplicación
    public interface IServicioPago
    {
        void ProcesarPago(decimal monto, string descripcion);
    }

    // API externa de PayPal con interfaz diferente
    public class PayPalAPI
    {
        public void EnviarDinero(decimal cantidad, string correo, string concepto)
        {
            Console.WriteLine($"PayPal: Enviando ${cantidad} a {correo} por concepto de '{concepto}'");
        }
    }

    // API externa de Stripe con interfaz diferente
    public class StripeAPI
    {
        public void CargarTarjeta(decimal importe, string id_tarjeta, string descripcion)
        {
            Console.WriteLine($"Stripe: Cargando ${importe} a tarjeta {id_tarjeta} - {descripcion}");
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

    // Ejemplo de uso
    public class EjemploAdapter
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Adapter ===\n");

            // Usar PayPal
            Console.WriteLine("--- Procesando pago con PayPal ---");
            IServicioPago procesadorPayPal = new AdaptadorPayPal();
            procesadorPayPal.ProcesarPago(100.50m, "Donación de órganos");

            // Usar Stripe
            Console.WriteLine("\n--- Procesando pago con Stripe ---");
            IServicioPago procesadorStripe = new AdaptadorStripe();
            procesadorStripe.ProcesarPago(100.50m, "Donación de órganos");

            // El código del cliente no cambia, solo cambia el adaptador
            Console.WriteLine("\n--- El cliente puede cambiar de proveedor fácilmente ---");
            ProcesarPagoCliente(new AdaptadorPayPal(), 50m, "Consulta médica");
            ProcesarPagoCliente(new AdaptadorStripe(), 50m, "Consulta médica");

            Console.WriteLine();
        }

        private static void ProcesarPagoCliente(IServicioPago procesador, decimal monto, string concepto)
        {
            procesador.ProcesarPago(monto, concepto);
        }
    }
}

