using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataService.DboModels;
using Client.Views;

namespace Client.ViewsModels
{
    public class CatalogViewModel : BaseVM
    {
        private List<Category> categories;

        public List<Category> Categories
        {
            get { return categories; }
            set { categories = value;
                OnPropertyChanged();
            }
        }
        public Command CatalogItemTapped { get; set; }
        public Command RefreshCommand { get; set; }
        public Command OutFromAccount { get; set; }

        public CatalogViewModel()
        {
            Categories = new List<Category>();
            RefreshCommand = new Command((object args) => Init());
            CatalogItemTapped = new Command((object args) => CategorySelected(args as Category));
            OutFromAccount = new Command((object args) => OutAccount());

            Init();

        }
        public async void OutAccount()
        {
            bool answer = await Shell.Current.DisplayAlert("Выход из аккаунта", "Вы действительно хотите выйти из аккаунта?", "Да", "Нет");
            if (answer)
            {
                Preferences.Default.Clear();
            }

        }
        public async void CategorySelected(Category category)
        {
            await Shell.Current.Navigation.PushAsync(new ProductsView(category));
        }
        public async void Init()
        {

            try
            {
                IsBusy = true;

                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                {
                    ShowSnackBar("Не стабильное интернет соединение");
                }
                else
                {
                    Categories = await restAPIService.GetCategories();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
