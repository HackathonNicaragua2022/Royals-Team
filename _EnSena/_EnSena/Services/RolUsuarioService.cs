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
    class RolUsuarioService
    {
        FirebaseClient client;
        public RolUsuarioService()
        {
            client = new FirebaseClient("alguna mamada de enlace");

        }



        public async Task<bool> isRolExist(RolUsuario toComprove)
        {
            var cuestionarioExist = (await client.Child("Roles").OnceAsync<RolUsuario>()).
                       Where(u => u.Object == toComprove).FirstOrDefault();

            return (toComprove != null);
        }


        public async Task<bool> RegistrarNuevoRol(RolUsuario newObj)
        {
            if (await isRolExist(newObj) == false)
            {
                await client.Child("Roles").PostAsync(newObj);

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> UpdateRol(RolUsuario toUpdate)
        {
            var toupdateObj = (await client.Child("Roles").OnceAsync<RolUsuario>())
                .FirstOrDefault(u => u.Object == toUpdate);

            await client.Child("Roles")
                .Child(toupdateObj.Key)
                .PutAsync(toUpdate);
            return true;
        }

        public async Task<bool> DeleteRol(RolUsuario toDelete)
        {
            var todeleteObj = (await client.Child("Roles").OnceAsync<RolUsuario>())
                .FirstOrDefault(u => u.Object == toDelete);

            await client.Child("Roles")
                .Child(todeleteObj.Key)
                .DeleteAsync();
            return true;
        }



    }
}
