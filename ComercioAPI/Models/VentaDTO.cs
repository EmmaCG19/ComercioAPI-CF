using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComercioAPI.Models
{
    public class VentaDTO
    {
        public int VentaId { get; set; }
        public VendedorDTO Vendedor { get; set; }
        public DateTime FechaVenta { get; set; }
        public List<DetalleVentaDTO> DetalleVenta { get; set; }
        //public double Importe { get; set; } -- Campo calculado
    }
}