using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ImagenUsuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string urlImagen { get; set; }

        public override string ToString()
        {
            return this.urlImagen.ToString();
        }
    }
}
