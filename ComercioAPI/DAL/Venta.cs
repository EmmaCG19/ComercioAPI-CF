using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercioAPI.DAL
{
    [Table("Ventas")]
    public class Venta
        //VentaId se va a repetir varias veces por cada producto que se haya vendido en la misma, por lo que no puede ser PK
    {
        [Key]
        [Column(Order = 1)]
        public int VentaId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CodProducto { get; set; }
        public virtual Producto Producto { get; set; }

        [Required]
        public int VendedorId { get; set; }
        public virtual Vendedor Vendedor { get; set; }

        public DateTime FechaDeVenta { get; set; }

        public int CantidadVendida { get; set; }
    }
}

