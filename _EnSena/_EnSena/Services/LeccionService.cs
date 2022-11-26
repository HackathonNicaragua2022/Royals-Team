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
    public class LeccionService
    {
        FirebaseClient client;
        public LeccionService()
        {
            client = new FirebaseClient("alguna mamada de enlace");

        }


        public async Task<List<Leccion>> GetLecciones()
        {
            var cuestionarioExist = (await client.Child("Lecciones").OnceAsync<Leccion>()).Select(x=>x.Object).ToList();
            return cuestionarioExist;
        }


        public async Task<List<Leccion>> GetLeccionesByCurseId(int IdCurso)
        {
            var cuestionarioExist = (await client.Child("Lecciones").OnceAsync<Leccion>()).Select(x => x.Object).ToList().FindAll(c=> c.idRecursoLeccion == IdCurso);
            return cuestionarioExist;
        }


        


        public async Task<bool> isLeccionExist(Leccion toComprove)
        {
            var cuestionarioExist = (await client.Child("Lecciones").OnceAsync<Leccion>()).
                       Where(u => u.Object == toComprove).FirstOrDefault();

            return (toComprove != null);
        }


        public async Task<bool> RegistarNuevaLeccion(Leccion newObj)
        {
            if (await isLeccionExist(newObj) == false)
            {
                await client.Child("Lecciones").PostAsync(newObj);

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> UpdateLeccion(Leccion toUpdate)
        {
            var toupdateObj = (await client.Child("Lecciones").OnceAsync<Leccion>())
                .FirstOrDefault(u => u.Object == toUpdate);

            await client.Child("Lecciones")
                .Child(toupdateObj.Key)
                .PutAsync(toUpdate);
            return true;
        }

        public async Task<bool> DeleteLeccion(Leccion toDelete)
        {
            var todeleteObj = (await client.Child("Lecciones").OnceAsync<Leccion>())
                .FirstOrDefault(u => u.Object == toDelete);

            await client.Child("Curses")
                .Child(todeleteObj.Key)
                .DeleteAsync();
            return true;
        }



    }
}
