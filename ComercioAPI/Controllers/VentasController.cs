using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComercioAPI.DAL;

namespace ComercioAPI.Controllers
{
    [RoutePrefix("api/ventas")]
    public class VentasController : ApiController
    {
        //Obtener todas las ventas
        [Route("")]
        public List<Venta> GetAllVentas()
        {
            throw new NotImplementedException();

        }

        //Obtener venta por id
        [Route("{idVenta:int}")]
        public Venta GetVentaPorId(int idVenta)
        {
            throw new NotImplementedException();

        }

        //Cargar una nueva venta
        [HttpPost]
        [Route("")]
        public void CargarVenta(Venta venta)
        {
            throw new NotImplementedException();

        }

        //Obtener las ventas que más recaudaron. Por default son las 3 que más recaudaron.
        [Route("mayor-importe/top/{cantidad:int?}")]
        public List<Venta> GetVentasMayorImporte(int cantidad = 3)
        {
            throw new NotImplementedException();

        }

        //Actualizar los datos de una venta
        [HttpPut]
        [Route("")]
        public HttpResponseMessage ActualizarVenta(Venta venta)
        {
            throw new NotImplementedException();

        }

        //Eliminar una venta
        [HttpDelete]
        [Route("{idVenta:int}")]
        public HttpResponseMessage EliminarVenta(int idVenta)
        {
            throw new NotImplementedException();
        }

        //Obtener las ventas realizadas por XXXX vendedor 
        [HttpGet]
        [Route("vendedores/{idVendedor:int}")]
        public List<Venta> ObtenerVentasDelVendedor(int idVendedor)
        {
            throw new NotImplementedException();
        }

        //Obtener las ventas donde figura XXXX producto
        [HttpGet]
        [Route("productos/{codProducto:int}")]
        public List<Venta> ObtenerVentasDelProducto(int codProducto)
        {
            throw new NotImplementedException();
        }

        //Obtener las ventas donde el vendedor XXXX vendio el producto XXXX
        [HttpGet]
        [Route("vendedores/{idVendedor:int}/productos/{codProducto:int}")]
        public List<Venta> ObtenerVentasDelVendedorProducto(int idVendedor, int codProducto)
        {
            throw new NotImplementedException();

        }

        //Obtener la cantidad de ventas realizadas por vendedor
        [HttpGet]
        [Route("~/api/vendedores/{idVendedor:int}/ventas/cantidad")]
        public int ObtenerCantidadVentasPorVendedor(int idVendedor)
        {
            throw new NotImplementedException();

        }
    }
}
