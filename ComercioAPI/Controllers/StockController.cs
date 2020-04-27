using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComercioAPI.DAL;

namespace ComercioAPI.Controllers
{
    [RoutePrefix("api/productos")]
    public class StockController : ApiController
    {
        //Obtener el stock de un producto con codigo XXXX
        [HttpGet]
        [Route("{codProducto:int}/stock")]
        public int ObtenerStockProducto(int codProducto)
        {
            throw new NotImplementedException();

        }

        //Obtener el stock de todos los productos
        [HttpGet]
        [Route("stock")]
        public List<int> ObtenerStockProductos()
        {
            throw new NotImplementedException();
        }

        //Obtener los productos que no tienen stock
        [HttpGet]
        [Route("stock/agotado")]
        public List<Producto> ObtenerProductosSinStock()
        {
            throw new NotImplementedException();

        }

        //Actualizar el stock de un producto
        [HttpPut]
        [Route("{codProducto:int}/stock")]
        public HttpResponseMessage ActualizarStock(int codProducto, Stock stockProducto)
        {

            throw new NotImplementedException();
        }


        //Nota: me estaría costando un poco el hecho de saber de donde definir los action methods, por ejemplo, 
        //en el caso del controlador Stock tuve dudas si dejarlo así o fusionarlo con el controlador de Productos, ya que uno depende del otro.
    }
}
