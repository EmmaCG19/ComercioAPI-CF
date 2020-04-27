using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComercioAPI.DAL;

namespace ComercioAPI.Controllers
{
    [RoutePrefix("api/categorias")]
    public class CategoriasController : ApiController
    {
        //Mostrar todas las categorias
        [Route("")]
        public List<Categoria> GetAllCategorias()
        {
            throw new NotImplementedException();

        }

        //Dar de alta a una categoria
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CargarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }
       
        //Eliminar una categoria por id
        [HttpDelete]
        [Route("{categoriaId:int}")]
        public HttpResponseMessage EliminarCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }

       
        //Actualizar una categoria
        [HttpPut]
        [Route("")]
        public HttpResponseMessage ActualizarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        
        //Obtener una categoria por Id
        [Route("{categoriaId:int}")]
        public Categoria GetCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }

        //Obtener una categoria por nombre
        [Route("{nombreCategoria:alpha}")]
        public Categoria GetCategoria(string nombreCategoria)
        {
            throw new NotImplementedException();
        }

        //Obtener los productos de una categoria por id
        [HttpGet]
        [Route("{categoriaId:int}/productos")]
        public List<Producto> ObtenerProductosPorCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }

        //Obtener los productos de una categoria por nombre
        [HttpGet]
        [Route("{nombreCategoria:alpha}/productos")]
        public List<Producto> ObtenerProductosPorCategoria(string nombreCategoria)
        {
            throw new NotImplementedException();
        }

        //Obtener el producto más vendido de una categoria
        [HttpGet]
        [Route("{categoriaId:int}/productos/mas-vendido")]
        public Producto ObtenerProductoMasVendidoPorCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }
    }
}
