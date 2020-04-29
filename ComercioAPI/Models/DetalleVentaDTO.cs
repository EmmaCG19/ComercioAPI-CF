using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ComercioAPI.Models
{
    public class DetalleVentaDTO
    {
        [Required(ErrorMessage ="El id de la venta es obligatorio.")]
        public VentaDTO Venta { get; set; }

        [Required(ErrorMessage ="El codigo del producto es obligatorio.")]
        public ProductoDTO Producto { get; set; }

        public int CantidadVendida { get; set; }
    }
}