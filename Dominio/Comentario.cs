using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoComentario
    {
        Activo = 1,
        Inactivo = 2,
        Suspendido = 3
    }
    public class Comentario
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public EstadoComentario Estado { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
