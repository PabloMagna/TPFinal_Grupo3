using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum Especie
    {
        [Description("Perro")]
        Perro = 1,

        [Description("Gato")]
        Gato = 2,

        [Description("Otro")]
        Otro = 3
    }
    public enum Estado
    {
        [Description("Activa")]
        Activa = 1,

        [Description("Borrada")]
        Borrada = 2,

        [Description("Finalizada")]
        Finalizada = 3,

        [Description("En Proceso")]
        EnProceso = 4,

        [Description("Baneada")]
        Baneada = 5
    }
    public class Publicacion
    {
        public int Id { get; set; } 
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public Especie Especie { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaHora { get; set; }
        public Estado Estado { get; set; }
        public int IDLocalidad { get; set; }
        public int IDProvincia { get; set; }
    }
}
