using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoAdopcion
    {
        Pendiente = 1,
        Aceptada = 2,
        Rechazada = 3
    }
    public class Adopcion
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public int IDPublicacion { get; set; }
        public EstadoAdopcion Estado { get; set; }
    }
}
