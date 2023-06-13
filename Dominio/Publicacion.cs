using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Publicacion
    {
        public int Id { get; set; } 
        public string Titulo { get; set; }
        public int IdMascota { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
