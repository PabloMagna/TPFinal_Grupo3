using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoUsuario
    {
        Activo = 1,
        Inactivo = 2,
        Eliminado = 3,
        Comprobado = 4
    }
    public enum TipoUsuario
    {
        Persona = 1,
        Refugio = 2
    }
    public class Usuario
    {   
        public int Id { get; set; }
        public TipoUsuario Tipo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        public EstadoUsuario Estado { get; set; }
        public bool EsAdmin { get; set; }
    }
}
