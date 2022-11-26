using System;
using System.Collections.Generic;
using System.Text;

namespace _EnSena.Models
{
    public class UsuarioCurso
    {
        public int idUsuarioCurso { get; set; }
        public int idCursoEnlace { get; set; }
        public int idUsuarioEnlace { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
