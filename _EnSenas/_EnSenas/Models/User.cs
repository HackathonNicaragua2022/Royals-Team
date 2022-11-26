using System;
using System.Collections.Generic;
using System.Text;

namespace _EnSenas.Models
{
    class User
    {
        public string idUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int idUserRol { get; set; }
        public int CoursePoint { get; set; }
    }
}
