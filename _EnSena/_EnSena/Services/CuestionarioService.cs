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
    public class CuestionarioService
    {
        FirebaseClient client;
        public CuestionarioService()
        {
            client = new FirebaseClient("alguna mamada de enlace");

        }


     
        public async Task<bool> IsCuestionarioExist(Cuestionario cuestionario)
        {
            var cuestionarioExist = (await client.Child("Cuestionarios").OnceAsync<Cuestionario>()).
                       Where(u => u.Object == cuestionario).FirstOrDefault();

            return (cuestionario != null);
        }


        public async Task<bool> RegistrarCuestionario(Cuestionario cuestionario)
        {
            if (await IsCuestionarioExist(cuestionario) == false)
            {
                await client.Child("Curses").PostAsync(cuestionario);

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> UpdateCuestionario(Cuestionario toUpdate)
        {
            var toupdateObj = (await client.Child("Cuestionarios").OnceAsync<Cuestionario>())
                .FirstOrDefault(u => u.Object == toUpdate);

            await client.Child("Cuestionarios")
                .Child(toupdateObj.Key)
                .PutAsync(toUpdate);
            return true;
        }

        public async Task<bool> DeleteCuestionario(Cuestionario toDelete)
        {
            var todeleteObj = (await client.Child("Curses").OnceAsync<Cuestionario>())
                .FirstOrDefault(u => u.Object == toDelete);

            await client.Child("Curses")
                .Child(todeleteObj.Key)
                .DeleteAsync();
            return true;
        }












    }
}
