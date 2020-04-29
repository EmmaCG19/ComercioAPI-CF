using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercioAPI.DAL
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int CodProducto { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }
        public double Precio { get; set; }

        [Range(0, 1000)]
        public int Stock { get; set; }

        //Un producto puede estar o no asignado a una categoria
        public int? CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        //Un producto va a estar en varias ventas
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }

    }
}


 