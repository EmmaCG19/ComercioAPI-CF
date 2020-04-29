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
        public IHttpActionResult GetAllVendedores()
        {
            List<VendedorDTO> vendedores = new List<VendedorDTO>();
            using (EcommerceDbContext context = new EcommerceDbContext())
            {
                vendedores = context.Vendedores
                                            .Select(v => new VendedorDTO()
                                            {
                                                VendedorId = v.VendedorId,
                                                Nombre = v.Nombre,
                                                Apellido = v.Apellido,
                                                FechaDeNacimiento = v.FechaDeNacimiento,
                                                NroDocumento = v.DNI
                                            })
                                            .ToList();
            }

            if (vendedores.Count == 0)
                return NotFound();

            return Ok(vendedores);
        }

        //Mostrar al vendedor con el id XXXX
        [Route("{idVendedor:int:min(1)}")]
        public IHttpActionResult GetVendedorPorId(int idVendedor)
        {
            if (idVendedor <= 0)
                return BadRequest("El id del vendedor ingresado es inválido");

            VendedorDTO vendedor = null;
            using (EcommerceDbContext context = new EcommerceDbContext())
            {
                vendedor = context.Vendedores
                            .Where(v => v.VendedorId == idVendedor)
                            .Select(v => new VendedorDTO()
                            {
                                VendedorId = v.VendedorId,
                                Nombre = v.Nombre,
                                Apellido = v.Apellido,
                                NroDocumento= v.DNI,
                                FechaDeNacimiento = v.FechaDeNacimiento,

                            }).FirstOrDefault<VendedorDTO>();
            }

            if (vendedor == null)
                return NotFound();

            return Ok(vendedor);

        }

        //Mostrar los productos vendidos por el vendedor con el id XXXX
        [Route("{idVendedor:int:min(1)}/productos")]
        public IHttpActionResult GetProductosPorVendedor(int idVendedor)
        {
            throw new NotImplementedException();

        }

        //Obtener a los N vendedores con mayor cantidad de ventas. Por default son 3.
        [Route("~/api/ventas/vendedores/top/{cantidad:int?}")]
        public IHttpActionResult GetVendedoresConMasVentas(int cantidad = 3)
        {
            throw new NotImplementedException();
        }

        //Cargar un vendedor
        [HttpPost]
        [Route("")]
        public IHttpActionResult CargarVendedor(VendedorDTO vendedor)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                try
                {
                    var vendedorDB = new Vendedor()
                    {
                        Nombre = vendedor.Nombre,
                        Apellido = vendedor.Apellido,
                        DNI = vendedor.NroDocumento,
                        FechaDeNacimiento = vendedor.FechaDeNacimiento

                    };
                    context.Vendedores.Add(vendedorDB);
                    context.SaveChanges();
                    vendedor.VendedorId = vendedorDB.VendedorId;
                }
                catch (Exception e)
                {
                    return BadRequest(e.InnerException.InnerException.Message);
                    
                }
            }

            return Ok(vendedor);
        }

        //Actualizar un vendedor
        [HttpPut]
        [Route("")]
        public IHttpActionResult ActualizarVendedor(VendedorDTO vendedor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                Vendedor vendedorDB = context.Vendedores.Find(vendedor.VendedorId);

                if (vendedorDB == null)
                    return NotFound();

                //Modifico los campos con los datos por parámetro
                vendedorDB.Nombre = vendedor.Nombre;
                vendedorDB.Apellido = vendedor.Apellido;
                vendedorDB.DNI = vendedor.NroDocumento;
                vendedorDB.FechaDeNacimiento = vendedor.FechaDeNacimiento;

                context.SaveChanges();

            }

            return Ok(vendedor.VendedorId);
        }

        //Eliminar un vendedor por id
        [HttpDelete]
        [Route("{idVendedor:int:min(1)}")]
        public IHttpActionResult EliminarVendedor(int idVendedor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var context = new EcommerceDbContext())
            {
                Vendedor vendedor = context.Vendedores.Find(idVendedor);

                if (vendedor == null)
                    return NotFound();

                context.Vendedores.Remove(vendedor);
                context.SaveChanges();
            }

            return Ok(idVendedor);
        }
    }

}
