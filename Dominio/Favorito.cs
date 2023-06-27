using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoFavorito
    {
        Activo = 1,
        Inactivo = 2
    }
    public class Favorito
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }
        public EstadoFavorito Estado { get; set; }
    }
}
