using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {   
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        public int Estado { get; set; }
        public bool EsAdmin { get; set; }
        public Usuario(string Cuenta) {
            if(Cuenta == "persona")
            {
                this.Tipo = 1;
            }
            else { this.Tipo = 2;}
            Password = string.Empty;
            Email = string.Empty;
            this.Estado = 1;
            EsAdmin = false;  
        }

        public Usuario()
        {
            Id = 0;
            this.Tipo= 1;
            Password = string.Empty;
            Email = string.Empty;
            this.Estado = 1;
            EsAdmin = false;
        }
    }
}
