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
        //Debo crear otra entidad Detalle_Ventas para permitir más de un articulo por venta

        [Key]
        public int VentaId { get; set; }

        [Required]
        public int VendedorId { get; set; }
        public virtual Vendedor Vendedor { get; set; }

        //Campo calculado(Detalle de venta -> IdVenta -> Producto.Precio * CantVendida)
        [NotMapped]
        public double Importe { get; set; }
        public DateTime FechaDeVenta { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }

    }
}

