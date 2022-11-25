using System;
using System.Collections.Generic;
using System.Text;

namespace _EnSena.Models
{
    class Cuestionario
    {
        public int idCuestionario { get; set; }
        public string DescripcionCuestionario { get; set; }
        public int idLeccionCuestionario { get; set; }
        public int DescripcionClaveCuestionario { get; set; }
        public bool EstadoCompletado { get; set; }
    }
}
