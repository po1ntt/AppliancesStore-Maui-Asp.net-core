using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class SignInViewModel : BaseVM
    {
        private string _Login;
        public string Login
        {
            get { return _Login; }
            set
            {
                _Login = value;
                OnPropertyChanged();
            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }
        public Command AuthUserCommand { get; set; }
        public SignInViewModel()
        {
            AuthUserCommand = new Command((object args) => AuthUser());
        }
        public async void AuthUser()
        {
            if (!string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password))
            {
                bool result = await restAPIService.AuhtorizeUser(Login, Password);
                if (result)
                {
                    Preferences.Set(nameof(Login), Login);
                    Preferences.Set(nameof(Password), Password);
                    await Shell.Current.Navigation.PopAsync();
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Заполните данные", "Пароль или логин пуст", "Ок");
            }
        }
    }
}
