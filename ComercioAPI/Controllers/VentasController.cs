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
    [RoutePrefix("api/ventas")]
    public class VentasController : ApiController
    {
        //Obtener todas las ventas
        [Route("")]
        public IHttpActionResult GetAllVentas()
        {
            var ventas = new List<VentaDTO>();
            using (EcommerceDbContext context = new EcommerceDbContext())
            {
                ventas = context.Ventas
                                        .Include("Vendedor")
                                        .Select(v => new VentaDTO()
                                        {
                                            VentaId = v.VentaId,
                                            FechaVenta = v.FechaDeVenta,
                                            Vendedor = new VendedorDTO()
                                            {
                                                VendedorId = v.Vendedor.VendedorId,
                                                Nombre = v.Vendedor.Nombre,
                                                Apellido = v.Vendedor.Apellido
                                            },

                                            //Falta agregar el detalle de venta con los productos que se vendieron
                                        }).ToList<VentaDTO>();
            }

            if (ventas.Count == 0)
                return NotFound();


            return Ok(ventas);
        }

        //Obtener venta por id
        [Route("{idVenta:int:min(1)}")]
        public IHttpActionResult GetVentaPorId(int idVenta)
        {
            if (idVenta <= 0)
                return BadRequest("El id de la venta ingresado es inválido");

            VentaDTO venta = null;
            using (EcommerceDbContext context = new EcommerceDbContext())
            {
                venta = context.Ventas
                            .Include("Vendedor")
                            .Where(v => v.VentaId == idVenta)
                            .Select(v => new VentaDTO()
                            {
                                VentaId = v.VentaId,
                                FechaVenta = v.FechaDeVenta,
                                Vendedor = new VendedorDTO()
                                {
                                    VendedorId = v.Vendedor.VendedorId,
                                    Nombre = v.Vendedor.Nombre,
                                    Apellido = v.Vendedor.Apellido
                                },

                            }).FirstOrDefault<VentaDTO>();
            }

            if (venta == null)
                return NotFound();

            return Ok(venta);

        }

        //Cargar una nueva venta
        [HttpPost]
        [Route("")]
        public IHttpActionResult CargarVenta(VentaDTO venta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                try
                {
                    var ventaDB = new Venta()
                    {
                        VendedorId = venta.Vendedor.VendedorId,
                        FechaDeVenta = venta.FechaVenta,

                    };

                    context.Ventas.Add(ventaDB);
                    context.SaveChanges();

                    venta.VentaId = ventaDB.VentaId;
                }
                catch (Exception e)
                {
                    return BadRequest(e.InnerException.InnerException.Message);
                }

            }

            return Ok(venta);

        }

        //Obtener las ventas que más recaudaron. Por default son las 3 que más recaudaron.
        [Route("mayor-importe/top/{cantidad:int?}")]
        public IHttpActionResult GetVentasMayorImporte(int cantidad = 3)
        {
            throw new NotImplementedException();

        }

        //Actualizar los datos de una venta
        [HttpPut]
        [Route("")]
        public IHttpActionResult ActualizarVenta(VentaDTO venta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                Venta ventaDB = context.Ventas.Find(venta.VentaId);

                if (ventaDB == null)
                    return NotFound();

                //Modifico los campos con los datos por parámetro
                ventaDB.VendedorId = venta.Vendedor.VendedorId;
                ventaDB.FechaDeVenta = venta.FechaVenta;

                context.SaveChanges();

            }

            return Ok(venta.VentaId);

        }

        //Eliminar una venta
        [HttpDelete]
        [Route("{idVenta:int:min(1)}")]
        public IHttpActionResult EliminarVenta(int idVenta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                Venta venta = context.Ventas.Find(idVenta);

                if (venta == null)
                    return NotFound();

                context.Ventas.Remove(venta);
                context.SaveChanges();
            }

            return Ok(idVenta);

        }

        //Obtener las ventas realizadas por XXXX vendedor 
        [HttpGet]
        [Route("vendedores/{idVendedor:int}")]
        public IHttpActionResult ObtenerVentasDelVendedor(int idVendedor)
        {
            throw new NotImplementedException();
        }

        //Obtener las ventas donde figura XXXX producto
        [HttpGet]
        [Route("productos/{codProducto:int}")]
        public IHttpActionResult ObtenerVentasDelProducto(int codProducto)
        {
            throw new NotImplementedException();
        }

        //Obtener las ventas donde el vendedor XXXX vendio el producto XXXX
        [HttpGet]
        [Route("vendedores/{idVendedor:int}/productos/{codProducto:int}")]
        public IHttpActionResult ObtenerVentasDelVendedorProducto(int idVendedor, int codProducto)
        {
            throw new NotImplementedException();

        }

        //Obtener la cantidad de ventas realizadas por vendedor
        [HttpGet]
        [Route("~/api/vendedores/{idVendedor:int}/ventas/cantidad")]
        public IHttpActionResult ObtenerCantidadVentasPorVendedor(int idVendedor)
        {
            throw new NotImplementedException();

        }
    }
}
