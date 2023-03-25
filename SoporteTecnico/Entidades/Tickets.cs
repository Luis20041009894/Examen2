using System;

namespace Entidades
{
    public class Tickets
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string IdentidadCliente { get; set; }
        public string CodigoUsuario { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string DescripcionRespuesta { get; set; }
        public decimal Precio { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }



        public Tickets()
        {
        }

        public Tickets(int id, DateTime fecha, string identidadCliente, string codigoUsuario, string tipoSoporte, string descripcionSolicitud, string descripcionRespuesta, decimal precio, decimal iSV, decimal descuento, decimal subTotal, decimal total)
        {
            Id = id;
            Fecha = fecha;
            IdentidadCliente = identidadCliente;
            CodigoUsuario = codigoUsuario;
            TipoSoporte = tipoSoporte;
            DescripcionSolicitud = descripcionSolicitud;
            DescripcionRespuesta = descripcionRespuesta;
            Precio = precio;
            ISV = iSV;
            Descuento = descuento;
            SubTotal = subTotal;
            Total = total;
        }
    }


}
