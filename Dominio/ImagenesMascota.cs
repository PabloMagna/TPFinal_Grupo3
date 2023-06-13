using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class ImagenesMascota
    {
        public int Id { get; set; }
        public int IdMascota { get; set; }
        public string urlImagen { get; set; }

        public override string ToString()
        {
            return this.urlImagen.ToString();
        }
    }
}
