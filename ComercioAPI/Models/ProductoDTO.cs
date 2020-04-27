using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComercioAPI.DAL;

namespace ComercioAPI.Models
{
    public class ProductoDTO
    {
        public int CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public CategoriaDTO Categoria { get; set; }

    }
}