using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComercioAPI.DAL;

namespace ComercioAPI.Models
{
    public class VendedorDTO
    {
        public int VendedorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NroDocumento { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
    }
}