using System;
using System.Collections.Generic;
using System.Text;

namespace _EnSena.Models
{
    public class Curso
    {
        public int idCurso { get; set; }
        public string DecripcionCurso { get; set; }
        public int idUsuarioregistro { get; set; }
        public string TituloCurso { get; set; }
        public int puntuacionMinimaRequerida { get; set; }

    }
}
