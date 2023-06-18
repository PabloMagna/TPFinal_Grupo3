using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Adopcion
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public int IDPublicacion { get; set; }
        public int Estado { get; set; }
    }
}
