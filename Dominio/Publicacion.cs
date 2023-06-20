using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Publicacion
    {
        public int Id { get; set; } 
        public string Titulo { get; set; }
        public int Especie { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public DateTime FechaHora { get; set; }
        public int IDProvincia { get; set; }
        public int IDLocalidad { get; set; }
    }
}
