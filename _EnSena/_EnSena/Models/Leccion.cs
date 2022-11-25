using System;
using System.Collections.Generic;
using System.Text;

namespace _EnSena.Models
{
    class Leccion
    {
        public int idLeccion { get; set; }
        public string TituloLeccion { get; set; }
        public string DescripcionLeccion { get; set; }
        public int idRecursoLeccion { get; set; }
    }
}
