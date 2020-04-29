using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercioAPI.DAL
{
    [Table("Vendedores")]
    public class Vendedor
    {
        public int VendedorId { get; set; }

        [MaxLength(20)]
        public string Nombre { get; set; }

        [MaxLength(20)]
        public string Apellido { get; set; }

        [Range(10000000,99999999)]
        public int DNI { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
    }
}