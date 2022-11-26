using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Firebase.Database.Query;
using _EnSena.Models;
using Firebase.Database;
using System.Threading.Tasks;

namespace _EnSena.Services
{
    public class CursoService
    {
        FirebaseClient client;
        public CursoService()
        {
            client = new FirebaseClient("alguna mamada de enlace");

        }


     

        public async Task<bool> IsCurseExist(Curso cursonuevo)
        {
            var curso = (await client.Child("Cursos").OnceAsync<Curso>()).
                       Where(u => u.Object == cursonuevo).FirstOrDefault();

            return (curso != null);
        }


        public async Task<bool> RegistrarCurso(Curso nuevocurso)
        {
            if (await IsCurseExist(nuevocurso) == false)
            {
                await client.Child("Curses").PostAsync(nuevocurso);

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> UpdateCurso(Curso curseUpdate)
        {
            var toupdateCurse = (await client.Child("Curses").OnceAsync<Curso>())
                .FirstOrDefault(u => u.Object == curseUpdate);

            await client.Child("Curses")
                .Child(toupdateCurse.Key)
                .PutAsync(curseUpdate);
            return true;
        }

        public async Task<bool> deleteCurse(Curso cursoDel)
        {
            var toDelCurso = (await client.Child("Curses").OnceAsync<Curso>())
                .FirstOrDefault(u => u.Object == cursoDel);

            await client.Child("Curses")
                .Child(toDelCurso.Key)
                .DeleteAsync();
            return true;
        }






    }
}
