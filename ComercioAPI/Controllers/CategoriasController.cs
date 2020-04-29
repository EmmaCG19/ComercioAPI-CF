using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComercioAPI.DAL;
using ComercioAPI.Models;

namespace ComercioAPI.Controllers
{
    [RoutePrefix("api/categorias")]
    public class CategoriasController : ApiController
    {
        //Mostrar todas las categorias
        [Route("")]
        public IHttpActionResult GetAllCategorias()
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            using (EcommerceDbContext context = new EcommerceDbContext())
            {
                categorias = context.Categorias
                                            .Select(c => new CategoriaDTO()
                                            {
                                                CategoriaId= c.CategoriaId,
                                                Nombre = c.Descripcion
                                            })
                                            .ToList();

            }

            if (categorias.Count == 0)
                return NotFound();

            return Ok(categorias);

        }

        //Dar de alta a una categoria
        [HttpPost]
        [Route("")]
        public IHttpActionResult CargarCategoria(CategoriaDTO categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                //Instanciando un objeto de la clase categoria
                try
                {
                    var catDB = new Categoria()
                    {
                        Descripcion = categoria.Nombre

                    };

                    context.Categorias.Add(catDB);
                    context.SaveChanges();

                    //Guardar el id de la categoria registrada
                    categoria.CategoriaId = catDB.CategoriaId;
                }
                catch (Exception e)
                {
                    return BadRequest(e.InnerException.InnerException.Message);
                    
                }

            }

            return Ok(categoria);

        }
       
        //Eliminar una categoria por id
        [HttpDelete]
        [Route("{categoriaId:int:min(1)}")]
        public IHttpActionResult EliminarCategoria(int categoriaId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                Categoria catDB = context.Categorias.Find(categoriaId);

                if (catDB == null)
                    return NotFound();

                context.Categorias.Remove(catDB);
                context.SaveChanges();
            }

            return Ok(categoriaId);
        }

        //Actualizar una categoria
        [HttpPut]
        [Route("")]
        public IHttpActionResult ActualizarCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                Categoria catDB = context.Categorias.Find(categoria.CategoriaId);

                if (catDB == null)
                    return NotFound();

                //Modifico los campos con los datos por parámetro
                catDB.Descripcion = categoria.Descripcion;

                context.SaveChanges();

            }

            return Ok(categoria.CategoriaId);

        }
        
        //Obtener una categoria por Id
        [Route("{categoriaId:int:min(1)}")]
        public IHttpActionResult GetCategoriaPorId(int categoriaId)
        {
            if (categoriaId <= 0)
                return BadRequest("El id ingresado es inválido");

            CategoriaDTO categoria = null;
            using (EcommerceDbContext context = new EcommerceDbContext())
            {
                //Reutilizar este código en una función
                categoria = context.Categorias
                            .Include("Producto")
                            .Where(c => c.CategoriaId == categoriaId)
                            .Select(c => new CategoriaDTO()
                            {
                                CategoriaId = c.CategoriaId,
                                Nombre = c.Descripcion,
                                Productos = c.Productos
                                                     .Select(p => new ProductoDTO()
                                                     {
                                                         CodProducto = p.CodProducto,
                                                         Descripcion = p.Descripcion,
                                                         Precio = p.Precio,
                                                         Stock = p.Stock,

                                                     })
                                                    .ToList<ProductoDTO>()



                                                    //.Where(p => p.CategoriaId == c.CategoriaId)
                                                    //.Select(p => new ProductoDTO() { CodProducto = p.CodProducto })
                                                    //.ToList<ProductoDTO>()
                            }).FirstOrDefault<CategoriaDTO>();
            }

            if (categoria == null)
                return NotFound();

            return Ok(categoria);

        }

        //Obtener una categoria por nombre
        [Route("{nombreCategoria:alpha}")]
        public IHttpActionResult GetCategoria(string nombreCategoria)
        {
            throw new NotImplementedException();
        }

        //Obtener los categorias de una categoria por id
        [HttpGet]
        [Route("{categoriaId:int}/productos")]
        public IHttpActionResult ObtenerProductosPorCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }

        //Obtener los categorias de una categoria por nombre
        [HttpGet]
        [Route("{nombreCategoria:alpha}/productos")]
        public IHttpActionResult ObtenerProductosPorCategoria(string nombreCategoria)
        {
            throw new NotImplementedException();
        }

        //Obtener el categoria más vendido de una categoria
        [HttpGet]
        [Route("{categoriaId:int}/productos/mas-vendido")]
        public IHttpActionResult ObtenerProductoMasVendidoPorCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }
    }
}
