using System;

namespace SistemaDonacion.DTOs
{
    public class CriterioBusquedaBitacoraDto
    {
        public int? UsuarioId { get; set; }
        public string Tabla { get; set; }
        public string Accion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? RegistroId { get; set; }
        public int? Pagina { get; set; }
        public int? TamanioPagina { get; set; }

        internal CriterioBusquedaBitacoraDto() { }

        public static ConstructorBusquedaBitacora Construir => new ConstructorBusquedaBitacora();
    }

    public class ConstructorBusquedaBitacora
    {
        private int? _usuarioId;
        private string _tabla;
        private string _accion;
        private DateTime? _fechaInicio;
        private DateTime? _fechaFin;
        private int? _registroId;
        private int? _pagina = 1;
        private int? _tamanioPagina = 10;

        public ConstructorBusquedaBitacora PorUsuario(int usuarioId)
        {
            _usuarioId = usuarioId;
            return this;
        }

        public ConstructorBusquedaBitacora PorTabla(string tabla)
        {
            _tabla = tabla;
            return this;
        }

        public ConstructorBusquedaBitacora PorAccion(string accion)
        {
            _accion = accion;
            return this;
        }

        public ConstructorBusquedaBitacora EnRangoDeFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            return this;
        }

        public ConstructorBusquedaBitacora Desde(DateTime fechaInicio)
        {
            _fechaInicio = fechaInicio;
            return this;
        }

        public ConstructorBusquedaBitacora Hasta(DateTime fechaFin)
        {
            _fechaFin = fechaFin;
            return this;
        }

        public ConstructorBusquedaBitacora PorRegistro(int registroId)
        {
            _registroId = registroId;
            return this;
        }

        public ConstructorBusquedaBitacora ConPaginacion(int pagina, int tamanioPagina)
        {
            _pagina = pagina;
            _tamanioPagina = tamanioPagina;
            return this;
        }

        public CriterioBusquedaBitacoraDto Construir()
        {
            return new CriterioBusquedaBitacoraDto
            {
                UsuarioId = _usuarioId,
                Tabla = _tabla,
                Accion = _accion,
                FechaInicio = _fechaInicio,
                FechaFin = _fechaFin,
                RegistroId = _registroId,
                Pagina = _pagina,
                TamanioPagina = _tamanioPagina
            };
        }
    }
}

