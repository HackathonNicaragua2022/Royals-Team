﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _EnSena.Models
{
    public class Usuarios
    {
        public int idUsuarios { get; set; }
        public string user { get; set; }
        public string psswd { get; set; }
        public string NombreCompleto { get; set; }
        public int idRolUsuario { get; set; }
        public int puntuacionCursos { get; set; }
    }
}
