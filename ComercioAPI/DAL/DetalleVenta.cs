using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercioAPI.DAL
{
    [Table("DetalleVentas")]
    public class DetalleVenta
    {
        [Key]
        [Column(Order = 1)]
        public int VentaId { get; set; }
        public virtual Venta Venta { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CodProducto { get; set; }
        public virtual Producto Producto {get;set;}

        [Required]
        [Range(1,1000)]
        public int CantVendida { get; set; }

    }
}