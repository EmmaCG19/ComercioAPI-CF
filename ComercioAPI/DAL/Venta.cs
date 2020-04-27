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
    {
        public int VentaId { get; set; }
       
        [Required]
        public int VendedorId { get; set; }
        public virtual Vendedor Vendedor { get; set; }

        [Required]
        public int CodProducto { get; set; }
        public virtual Producto Producto { get; set; }

        public DateTime FechaDeVenta { get; set; }

        //Data validation customizada para que la cantidad vendida no supere el stock del producto
        public int CantidadVendida { get; set; }
    }
}

