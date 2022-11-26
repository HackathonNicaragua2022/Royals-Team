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
    public class UserServices
    {

        FirebaseClient client;

        public UserServices()
        {
            client = new FirebaseClient("alguna mamada de enlace");

        }

        public async Task<bool> IsUserExist(string uname)
        {
            var user = (await client.Child("Users").OnceAsync<Usuarios>()).
                       Where(u => u.Object.user == uname).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(Usuarios nuevousuario)
        {
            if (await IsUserExist(nuevousuario.user) == false)
            {
                await client.Child("Users").PostAsync(new Usuarios()
                {
                    user = nuevousuario.user,
                    psswd= nuevousuario.psswd,
                    NombreCompleto=nuevousuario.NombreCompleto,
                    puntuacionCursos=0,
                    idRolUsuario=2,
                });

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> UpdateUser(Usuarios userupdate)
        {
            var toupdateUser = (await client.Child("Users").OnceAsync<Usuarios>())
                .FirstOrDefault(u => u.Object.user == userupdate.user);

            await client.Child("Users")
                .Child(toupdateUser.Key)
                .PutAsync(userupdate);
            return true;
        }

        public async Task<bool> DeleteUser(Usuarios user)
        {
            var toupdateUser = (await client.Child("Users").OnceAsync<Usuarios>())
                .FirstOrDefault(u => u.Object == user);

            await client.Child("Users")
                .Child(toupdateUser.Key)
                .DeleteAsync();
            return true;
        }




    }
}
