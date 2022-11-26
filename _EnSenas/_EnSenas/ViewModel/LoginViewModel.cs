using _EnSenas.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace _EnSenas.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        private string _Username;
        private string _Password;
        private bool _IsBusy;
        private bool _Result;

        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }

            get
            {
                return this._Username;
            }
        }

        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }

            get
            {
                return this._Password;
            }
        }

        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }

            get
            {
                return this._IsBusy;
            }
        }

        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }

            get
            {
                return this._Result;
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);

                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Bienvenido", "Usuario Registrado Correctamente", "Ok");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "El Usuario Ya Existe", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var userSrvice = new UserService();
                Result = await userSrvice.LoginUser(Username, Password);

                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña Incorecta", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
