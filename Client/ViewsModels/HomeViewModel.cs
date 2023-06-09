﻿
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
using Client.DataService;

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
        private List<ProductAndCategoryModel> _ProductAndCategory;

        public List<ProductAndCategoryModel> ProductsAndCategory
        {
            get { return _ProductAndCategory; }
            set { _ProductAndCategory = value;
                OnPropertyChanged();
            }
        }
        public List<ProductAndCategoryModel> LastList { get; set; } = new List<ProductAndCategoryModel>();
        public Command BrandItemTapped { get; set; }

        public ObservableCollection<Brand> Brands { get; set; }

        public Command RefreshCommand { get; set; }
        public Command OutFromAccount { get; set; }
        public Command ShowPopup { get; set; }
        public Command ApperingCommand { get; set; }
         
        public Command GotoAuthPage { get; set; }
        public HomeViewModel()
        {
            Brands = new ObservableCollection<Brand>();
            ProductsAndCategory = new List<ProductAndCategoryModel>();
            RefreshCommand = new Command(async (object args) => await Init());
            ShowPopup = new Command((object args) => NeedAuthorized());
            ApperingCommand = new Command(async (object args) => await Init());
            GotoAuthPage = new Command(async (object args) => await Shell.Current.Navigation.PushAsync(new SignInView()));
            BrandItemTapped= new Command((object args) => BrandSelected(args as Brand));
            OutFromAccount = new Command((object args) => OutAccount());

        }
        public async void BrandSelected(Brand brand)
        {
            ShowLoadingPopup();
            IsBusy = true;
            await Shell.Current.Navigation.PushAsync(new ProductsView(brand));
            IsBusy = false;
            await MopupService.Instance.PopAllAsync();
        }
        public async void OutAccount()
        {
            bool answer = await Shell.Current.DisplayAlert("Выход из аккаунта", "Вы действительно хотите выйти из аккаунта?", "Да", "Нет");
            if (answer)
            {
                Preferences.Default.Clear();
                StaticValues.Favorites.Clear();
                StaticValues.Basket.Clear();
                await Init();
            }
          
        }
        

        public async Task Init()
        {
            if(Refreshing == true)
                return;
            try
            {
                ShowLoadingPopup();
                IsBusy = true;
                Refreshing = true;
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                {
                    ShowSnackBar("Интернет соединение не стабильно");
                }
                List<Basket> basket = new List<Basket>();

                if (!string.IsNullOrWhiteSpace(Preferences.Default.Get("Login", "")))
                {
                    basket = await restAPIService.GetUserBasketById();
                    FillBasketAndFavorites();
                }
               
                if (ProductsAndCategory.Count == 0)
                {
                    List<ProductAndCategoryModel> products = new List<ProductAndCategoryModel>();

                    LastList = await restAPIService.GetProductAndCategoryModels();
                    foreach (var item in LastList)
                    {
                        foreach(var product in item.products)
                        {
                            if (StaticValues.Favorites.Any(a=> a.IdProduct == product.IdProduct))
                            {
                                product.IsFavorite = "1";
                            }
                            else
                            {
                                product.IsFavorite = "0";
                            }
                            if (basket.Any(a => a.ProductId == product.IdProduct))
                            {
                                product.IsBasket = "1";
                            }
                            else
                            {
                                product.IsBasket = "0";
                            }
                        }
                        products.Add(item);
                       
                    }
                   
                    ProductsAndCategory = products;

                }
                else
                {


                    foreach (var item in ProductsAndCategory)
                    {
                        foreach (var product in item.products)
                        {
                            if (StaticValues.Favorites.Any(a => a.IdProduct == product.IdProduct))
                            {
                                product.IsFavorite = "1";
                            }
                            else
                            {
                                product.IsFavorite = "0";
                            }
                            if (basket.Any(a => a.ProductId == product.IdProduct))
                            {
                                product.IsBasket = "1";
                            }
                            else
                            {
                                product.IsBasket = "0";
                            }
                        }
                    }

                }
                if(Brands.Count == 0)
                {
                    List<Brand> brands = await restAPIService.GetBrands();
                    if (brands.Count != 0)
                    {
                        foreach (var item in brands)
                        {
                            Brands.Add(item);
                        }
                    }
                }
              Refreshing = false;
            }
            catch (Exception ex)
            {
                Refreshing = false;


                ShowSnackBar(ex.Message);
            }
            finally
            {
                Refreshing = false;
                IsBusy = false;
                await MopupService.Instance.PopAllAsync();

            }

        }
    }
}
