using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Refugio
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string UrlImagen { get; set; }
        public int IDLocalidad { get; set; }
        public int IDProvincia { get; set; }
        public string Telefono { get; set; }
    }
}
