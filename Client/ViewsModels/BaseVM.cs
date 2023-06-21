using Client.DataService;
using Client.DataService.DboModels;
using Client.DataService.ServiceAPI;
using Client.Views.Popups;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Mopups.Interfaces;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class BaseVM : INotifyPropertyChanged
    {
       
        public IPopupNavigation popupNavigation;

        private bool _IsNotUserAuth;
        public async void ShowLoadingPopup()
        {
            await MopupService.Instance.PushAsync(new LoadingPopup());
        }
		public bool IsNotUserAuth
        {
			get { return _IsNotUserAuth; }
			set { _IsNotUserAuth = value;
				OnPropertyChanged();
			}
		}
        private bool _UserAuth;

        public bool UserAuth
        {
            get { return _UserAuth; }
            set
            {
                _UserAuth = value;
                IsNotUserAuth = !_UserAuth;
                OnPropertyChanged();
            }
        }
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }
        private bool _Refreshing;

        public bool Refreshing
        {
            get { return _Refreshing; }
            set
            {
                _Refreshing = value;
                OnPropertyChanged();
            }
        }
        public Command AddToFavoriteCommand { get;
            set;
        }
        public Command AddProductToBasket { get
        ;set; }
        public NetworkAccess networkAccess { get; set; }
        public IRestAPIService restAPIService { get; set; }
        public BaseVM()
        {
            popupNavigation = new PopupNavigation();
            restAPIService = new RestAPIService();
            networkAccess = Connectivity.NetworkAccess;
            AddToFavoriteCommand = new Command(async (object args) => AddToFavorites(args as Product));
            AddProductToBasket = new Command(async (object args) => AddToBasket(args as Product));
            if(StaticValues.Favorites == null)
            {
                StaticValues.Favorites = new List<Product>();
                StaticValues.Basket = new List<Basket>();
                if (!string.IsNullOrWhiteSpace(Preferences.Default.Get("Login", "")))
                {
                    FillBasketAndFavorites();
                    UserAuth = true;
                }
                else
                    UserAuth = false;
            }
          
        }
        public async void FillBasketAndFavorites()
        {

            if (IsBusy == true)
                return;
            try
            {
                IsBusy = true;
                StaticValues.Favorites = await restAPIService.GetUserFavorites();
                StaticValues.Basket = await restAPIService.GetUserBasketById();
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
        public async void ShowSnackBar(string message)
        {
            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Orange,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(5),
                CharacterSpacing = 0


            };
            TimeSpan duration = TimeSpan.FromSeconds(2);
            var snacbarTest = Snackbar.Make(message, duration: duration, actionButtonText: "Ок", visualOptions: snackbarOptions);


            await snacbarTest.Show();
        }
        public async void AddToBasket(Product product)
        {
            if (IsBusy == true)
                return;
            try
            {
                IsBusy = true;

                if (!string.IsNullOrWhiteSpace(Preferences.Get("Login", "")))
                {
                    if (product.IsBasket != "1")
                    {
                        var addAction = await restAPIService.AddProductToBasket(new Basket
                        {
                            ProductId = product.IdProduct,
                            UserId = Preferences.Get("id_user", 0),
                            CountProduct = 1
                        });
                        if (addAction == true)
                        {
                            ShowSnackBar("Товар добавлен в корзину");
                            product.IsBasket = "1";
                            StaticValues.Basket.Add(new Basket
                            {
                                ProductId = product.IdProduct,
                                UserId = Preferences.Get("id_user", 0),
                                CountProduct = 1
                            });

                        }
                        else
                        {
                            ShowSnackBar("Что-то пошло не так");
                        }
                    }
                    else
                    {
                        var addAction = await restAPIService.DeleteProductFromBasket(new Basket
                        {
                            ProductId = product.IdProduct,
                            UserId = Preferences.Get("id_user", 0),
                            CountProduct = 1
                        });
                        if (addAction == true)
                        {
                            ShowSnackBar("Товар удален из корзины");
                            product.IsBasket = "0";
                            StaticValues.Basket = await restAPIService.GetUserBasketById();
                        }
                        else
                        {
                            ShowSnackBar("Что-то пошло не так");

                        }
                    }

                }
                else
                {
                    NeedAuthorized();
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
        public async void AddToFavorites(Product product)
        {
            if (!string.IsNullOrWhiteSpace(Preferences.Get("Login", "")))
            {
                if(product.IsFavorite == "1")
                {
                    var addAction = await restAPIService.DeleteProductFromFavorite(product.IdProduct);
                    if (addAction == true)
                    {
                        ShowSnackBar("Товар удален из избранного");
                        product.IsFavorite = "0";
                        StaticValues.Favorites.Remove(product);

                    }
                }
                else
                {
                    var addAction = await restAPIService.AddProductToFavorite(new Favorite
                    {
                        ProductId = product.IdProduct,
                        UserId = Preferences.Get("id_user", 0)
                    });
                    if (addAction == true)
                    {
                        ShowSnackBar("Товар добавлен в избранное");
                        product.IsFavorite = "1";

                        StaticValues.Favorites.Add(product);

                    }
                }
               
            }
            else
            {
                NeedAuthorized();
            }
        }
        public async void NeedAuthorized()
        {
            await MopupService.Instance.PushAsync(new NotAuthorizedPopupView());
        }
        public void userAuthChanges()
        {
            if (!string.IsNullOrWhiteSpace(Preferences.Get("Login", "")))
                UserAuth = true;
            else
                UserAuth = false;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
