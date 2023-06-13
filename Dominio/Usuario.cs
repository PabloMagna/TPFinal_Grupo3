using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string Password { get; set; }
        public string UrlImagen { get; set; }
        public string Email { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
    }
}
