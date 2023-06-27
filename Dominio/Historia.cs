using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoHistoria
    {
        Activo = 1,
        Inactivo = 2,
        Eliminado = 3
    }
    public class Historia
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public DateTime FechaHora { get; set; }
        public EstadoHistoria Estado { get; set; }
    }
}
