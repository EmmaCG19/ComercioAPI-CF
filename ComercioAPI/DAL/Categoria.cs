using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercioAPI.DAL
{
    [Table("Categorias")]
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}