﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Mascota
    {
        public int Id { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

    }
}
