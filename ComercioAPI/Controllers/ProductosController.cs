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
                                                        CategoriaId = p.Categoria.CategoriaId,
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
        public IHttpActionResult GetProductoPorCodigo(int codProducto)
        {
            if (codProducto <= 0)
                return BadRequest("El código de producto ingresado es inválido");

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
                                Precio = p.Precio,
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
        public IHttpActionResult CargarProducto(ProductoDTO producto)
        {
            using (var context = new EcommerceDbContext())
            {
                //Instanciando un objeto de la clase Producto
                try
                {

                    var prodDB = new Producto()
                    {
                        Descripcion = producto.Descripcion,
                        Stock = producto.Stock,
                        CategoriaId = producto.Categoria.CategoriaId,
                    };


                    context.Productos.Add(prodDB);
                    context.SaveChanges();
                    producto.CodProducto = prodDB.CodProducto;
                }
                catch (Exception)
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);
                }


            }

            //Retornar un objeto de la clase ProductoDTO con el id generado
            return Ok(producto);
        }

        //Eliminar producto por id
        [HttpDelete]
        [Route("{codProducto:int:min(1)}")]
        public IHttpActionResult EliminarProducto(int codProducto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                Producto prod = context.Productos.Find(codProducto);

                if (prod == null)
                    return NotFound();

                context.Productos.Remove(prod);
                context.SaveChanges();
            }

            return Ok(codProducto);
        }

        //Actualizar producto
        [HttpPut]
        [Route("")]
        public IHttpActionResult ActualizarProducto(ProductoDTO producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                Producto prodDB = context.Productos.Find(producto.CodProducto);

                if (prodDB == null)
                    return NotFound();

                //Modifico los campos con los datos por parámetro
                prodDB.Descripcion = producto.Descripcion;
                prodDB.Stock = producto.Stock;
                prodDB.Precio = producto.Precio;
                prodDB.CategoriaId = producto.Categoria.CategoriaId;

                context.SaveChanges();

            }

            return Ok(producto.CodProducto);
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
