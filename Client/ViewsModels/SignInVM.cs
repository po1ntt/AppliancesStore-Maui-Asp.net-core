using Android.App;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public partial class SignInVM : BaseVM
    {
        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string phone;

        [RelayCommand]
        public async void authorizeUser()
        {
            try
            {
                IsBusy = true;
                Users users = await DataService.UsersService.usersService.GetuserInfo(Phone, Password);
                if(users.id_users != 0)
                {
                   await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Неверно введенные данные", "Ок");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
