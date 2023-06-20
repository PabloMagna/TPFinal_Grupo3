using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ImagenMascota
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public string urlImagen { get; set; }

        public override string ToString()
        {
            return this.urlImagen.ToString();
        }
    }
}
