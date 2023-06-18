using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
