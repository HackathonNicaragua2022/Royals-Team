using System;
using System.Collections.Generic;
using System.Text;

namespace _EnSena.Models
{
    public class Cuestionario
    {
        public int idCuestionario { get; set; }
        public string DescripcionCuestionario { get; set; }
        public int idLeccionCuestionario { get; set; }
        public int DescripcionClaveCuestionario { get; set; }
        public bool EstadoCompletado { get; set; }
        public int puntuacionMinima { get; set; }
        public int puntuacionCuestionario { get; set; }
    }
}
