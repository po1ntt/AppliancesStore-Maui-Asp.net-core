
using Client.DataService.SpecialModels;
using Client.Views.Popups;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Mopups.Interfaces;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Client.DataService.DboModels;
using Client.Views;

namespace Client.ViewsModels
{

    public class HomeViewModel : BaseVM
    {
        /*     private List<ProductAndCategoryModel> productsAndCategory;

             public List<ProductAndCategoryModel> ProductsAndCategory
             {
                 get { return productsAndCategory; }
                 set { productsAndCategory = value;
                     OnPropertyChanged();
                 }
             }*/
        public ObservableCollection<ProductAndCategoryModel> ProductsAndCategory { get; set; }
        public ObservableCollection<Brand> Brands { get; set; }

        public Command RefreshCommand { get; set; }
        
        public Command ShowPopup { get; set; }
        public Command GotoAuthPage { get; set; }
        public HomeViewModel()
        {
            ProductsAndCategory = new ObservableCollection<ProductAndCategoryModel>();
            Brands = new ObservableCollection<Brand>();
            RefreshCommand = new Command((object args) => Init());
            ShowPopup = new Command((object args) => NeedAuthorized());
            GotoAuthPage = new Command(async (object args) => await Shell.Current.Navigation.PushAsync(new SignInView()));
            Init();
        }
        public async void Init()
        {
            try
            {
                IsBusy = true;
                ProductsAndCategory.Clear();
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                {
                    ShowSnackBar("Интернет соединение не стабильно");
                }
                if(ProductsAndCategory.Count == 0)
                {
                    foreach(var item in await restAPIService.GetProductAndCategoryModels())
                    {
                        ProductsAndCategory.Add(item);
                    }
                }
                List<Brand> brands = await restAPIService.GetBrands();
                if(brands.Count != 0)
                {
                    foreach(var item in brands)
                    {
                        Brands.Add(item);
                    }
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {

                throw;
            }
           
           
        }
    }
}
