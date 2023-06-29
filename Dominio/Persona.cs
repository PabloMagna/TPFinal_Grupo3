using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }

        public int Dni { get; set; }
        public string Apellido { get;set; }
        public string UrlImagen { get; set; }
        public int IDLocalidad { get; set; }
        public int IDProvincia { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
