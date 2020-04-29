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
    [RoutePrefix("api/vendedores")]
    public class VendedoresController : ApiController
    {
        //Mostrar todos los vendedores
        [Route("")]
        public List<Vendedor> GetAllVendedores()
        {
            throw new NotImplementedException();

        }

        //Mostrar al vendedor con el id XXXX
        [Route("{idVendedor:int}")]
        public Vendedor GetVendedorPorId(int idVendedor)
        {

            throw new NotImplementedException();
        }

        //Mostrar los productos vendidos por el vendedor con el id XXXX
        [Route("{idVendedor:int}/productos")]
        public List<Producto> GetProductosPorVendedor(int idVendedor)
        {
            throw new NotImplementedException();

        }

        //Obtener a los N vendedores con mayor cantidad de ventas. Por default son 3.
        [Route("~/api/ventas/vendedores/top/{cantidad:int?}")]
        public List<Vendedor> GetVendedoresConMasVentas(int cantidad = 3)
        {
            throw new NotImplementedException();
        }


        //Cargar un vendedor
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CargarVendedor(Vendedor vendedor)
        {
            throw new NotImplementedException();
        }

        //Actualizar un vendedor
        [HttpPut]
        [Route("")]
        public HttpResponseMessage ActualizarVendedor(Vendedor vendedor)
        {
            throw new NotImplementedException();
        }


        //Eliminar un vendedor por id
        [HttpDelete]
        [Route("{idVendedor:int}")]
        public HttpResponseMessage EliminarVendedor(int idVendedor)
        {
            throw new NotImplementedException();
        }
    }
        
}
