using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoAdopcion
    {
        Pendiente= 1,
        Completada = 2,
        RechazadaPorDonante = 3,
        EliminadaPorAdoptante = 4,
        Devuelto = 5,
        EliminadoPorAdmin = 6,
        PublicacionBorrada = 7  
    }
    public class Adopcion
    {
        public int IDUsuario { get; set; }
        public int IDPublicacion { get; set; }
        public EstadoAdopcion Estado { get; set; }
        public DateTime FechaHora { get; set; }
        public string Comentario { get; set; }
    }
}
