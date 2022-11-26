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
    class UsuarioCursoService
    {
        FirebaseClient client;
        public UsuarioCursoService()
        {
            client = new FirebaseClient("alguna mamada de enlace");

        }



        public async Task<bool> isRecursoExist(Recurso toComprove)
        {
            var cuestionarioExist = (await client.Child("Recursos").OnceAsync<Recurso>()).
                       Where(u => u.Object == toComprove).FirstOrDefault();

            return (toComprove != null);
        }


        public async Task<bool> RegistrarNuevoRecurso(Recurso newObj)
        {
            if (await isRecursoExist(newObj) == false)
            {
                await client.Child("Recursos").PostAsync(newObj);

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<UsuarioCurso>> GetUsuarioCurso()
        {
            var cursos = (await client.Child("UserCurses").OnceAsync<UsuarioCurso>()).Select(x => x.Object).ToList();
            return cursos;
        }
        public async Task<List<UsuarioCurso>> GetUsuarioCursoById(int IdUser)
        {
            var cursos = (await client.Child("UserCurses").OnceAsync<UsuarioCurso>()).Select(x => x.Object).Where(x=>x.idUsuarioCurso == IdUser).ToList();
            return cursos;
        }
        public async Task<bool> UpdateRecurso(Recurso toUpdate)
        {
            var toupdateObj = (await client.Child("Recursos").OnceAsync<Recurso>())
                .FirstOrDefault(u => u.Object == toUpdate);

            await client.Child("Recursos")
                .Child(toupdateObj.Key)
                .PutAsync(toUpdate);
            return true;
        }

        public async Task<bool> DeleteRecurso(Recurso toDelete)
        {
            var todeleteObj = (await client.Child("Recursos").OnceAsync<Recurso>())
                .FirstOrDefault(u => u.Object == toDelete);

            await client.Child("Recursos")
                .Child(todeleteObj.Key)
                .DeleteAsync();
            return true;
        }


    }
}
