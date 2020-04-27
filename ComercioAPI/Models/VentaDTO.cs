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
        public ProductoDTO Producto { get; set; }
        public DateTime FechaVenta { get; set; }

    }
}