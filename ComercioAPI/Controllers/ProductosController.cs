using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComercioAPI.Models;
using ComercioAPI.DAL;

namespace ComercioAPI.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {

        //Mostrar todos los productos
        [Route("")]
        public IHttpActionResult GetAllProductos()
        {
            List<ProductoDTO> productos = new List<ProductoDTO>();
            using (EcommerceDbContext context = new EcommerceDbContext())
            {
                productos = context.Productos
                                            .Include("Categoria")
                                            .Select(p => new ProductoDTO()
                                            {
                                                CodProducto = p.CodProducto,
                                                Stock = p.Stock,
                                                Descripcion = p.Descripcion,
                                                Categoria = p.CategoriaId == null ? null :
                                                    new CategoriaDTO()
                                                    {
                                                        Nombre = p.Categoria.Descripcion
                                                    }
                                            })
                                            .ToList();

            }

            if (productos.Count == 0)
                return NotFound();

            return Ok(productos);
        }

        //Devolver el producto con el codigo XXXX
        [Route("{codProducto:int:min(1)}")]
        public IHttpActionResult GetProductoPorId(int codProducto)
        {
            if (codProducto <= 0)
                return BadRequest();

            ProductoDTO producto = null;
            using (EcommerceDbContext context = new EcommerceDbContext())
            {
                producto = context.Productos
                            .Include("Categoria")
                            .Where(p => p.CodProducto == codProducto)
                            .Select(p => new ProductoDTO()
                            {
                                CodProducto = p.CodProducto,
                                Descripcion = p.Descripcion,
                                Stock = p.Stock,
                                Categoria = p.CategoriaId == null ? null : new CategoriaDTO()
                                {
                                    Nombre = p.Categoria.Descripcion,
                                    CategoriaId = p.Categoria.CategoriaId
                                }

                            }).FirstOrDefault<ProductoDTO>();
            }

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        //Devolver el producto con el nombre XXXX
        [HttpGet]
        [Route("{nombreProducto:alpha}")]
        public ProductoDTO GetProductoPorNombre(string nombreProducto)
        {
            throw new NotImplementedException();
        }

        //Dar de alta un producto
        [HttpPost]
        [Route("")]
        public void CargarProducto()
        {
            HttpResponseMessage mensaje = new HttpResponseMessage();

            using (var context = new EcommerceDbContext())
            {
                //try
                //{
                //    context.Productos.Add(producto);
                //    context.SaveChanges();

                //    mensaje.StatusCode = HttpStatusCode.OK;
                //    mensaje.Content = new StringContent("El producto fue cargado exitosamente");
                //}
                //catch (Exception e)
                //{

                //    mensaje.StatusCode = HttpStatusCode.NotAcceptable;
                //    mensaje.Content = new StringContent(String.Format("El producto no pudo ser cargado. Excepción {0}", e.Message));
                //}

                //return mensaje;

                var p = new Producto() { Descripcion = "zapatos", Precio = 1500, Stock = 20 };
                context.Productos.Add(p);
                context.SaveChanges();
            }
        }

        //Eliminar producto por id
        [HttpDelete]
        [Route("{codProducto:int}")]
        public HttpResponseMessage EliminarProducto(int codProducto)
        {
            throw new NotImplementedException();
        }

        //Actualizar producto
        [HttpPut]
        [Route("")]
        public HttpResponseMessage ActualizarProducto(ProductoDTO producto)
        {
            throw new NotImplementedException();
        }

        //Obtener los productos mas vendidos
        [HttpGet]
        [Route("mas-vendidos")]
        public List<ProductoDTO> ObtenerProductosMasVendidos()
        {
            throw new NotImplementedException();
        }

        //Obtener los productos menos vendidos
        [HttpGet]
        [Route("menos-vendidos")]
        public List<ProductoDTO> ObtenerProductosMenosVendidos()
        {
            throw new NotImplementedException();

        }

    }
}
