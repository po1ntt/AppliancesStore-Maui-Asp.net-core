using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class RegistrationViewModel : BaseVM
    {
        private string _UserLogin;

        public string UserLogin
        {
            get { return _UserLogin; }
            set { _UserLogin = value;
                OnPropertyChanged();
            }
        }
        private string _UserPassword;

        public string UserPassword
        {
            get { return _UserPassword; }
            set
            {
                _UserPassword = value;
                OnPropertyChanged();
            }
        }
        private string _UserPasswordRepeat;

        public string UserPasswordRepeat
        {
            get { return _UserPasswordRepeat; }
            set
            {
                _UserPasswordRepeat = value;
                OnPropertyChanged();
            }
        }
        public Command RegisterUserCommad { get; set; }
        public async void RegisterUser()
        {
           if(!string.IsNullOrWhiteSpace(UserLogin)  && !string.IsNullOrWhiteSpace(UserPassword))
            {
                if(UserPassword == UserPasswordRepeat)
                {
                    User user = new User();
                    user.Login = UserLogin;
                    user.Password = UserPassword;

                    bool result = await restAPIService.RegistUser(user);
                    if (result)
                    {
                        ShowSnackBar("Регистрация прошла успешно");
                        await Shell.Current.Navigation.PopAsync();
                    }
                    else
                    {
                        ShowSnackBar("Ошибочкааа... Пользователь с таким логином уже существует");
                    }
                }
                else
                {
                    ShowSnackBar("Пароли не совпадают");
                }
            }
            else
            {
                ShowSnackBar("Заполните данные");
            }
        }
        public RegistrationViewModel()
        {
            RegisterUserCommad = new Command((object args) => RegisterUser());
        }
    }
}
