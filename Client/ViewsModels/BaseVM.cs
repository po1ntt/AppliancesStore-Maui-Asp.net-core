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
        private List<Product> _Favorites;

        public List<Product> Favorites
        {
            get { return _Favorites; }
            set
            {
                _Favorites = value;
                OnPropertyChanged();
            }
        }
        private List<Product> _Basket;

        public List<Product> Basket
        {
            get { return _Basket; }
            set
            {
                _Basket = value;
                OnPropertyChanged();
            }
        }
        public IPopupNavigation popupNavigation;

        private bool _IsNotUserAuth;

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
        public Command AddToFavoriteCommand { get;
            set;
        }
        public NetworkAccess networkAccess { get; set; }
        public IRestAPIService restAPIService { get; set; }
        public BaseVM()
        {
            popupNavigation = new PopupNavigation();
            restAPIService = new RestAPIService();
            networkAccess = Connectivity.NetworkAccess;
            AddToFavoriteCommand = new Command(async (object args) => AddToFavorites(args as Product));

            if (!string.IsNullOrWhiteSpace(Preferences.Get("Login", "")))
            {
                FillBasketAndFavorites();
                UserAuth = true;
            }
            else
                UserAuth = false;
        }
        public async void FillBasketAndFavorites()
        {
            Favorites = await restAPIService.GetUserFavorites();
            Basket = await restAPIService.GetUserBasket();
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
            if (!string.IsNullOrWhiteSpace(Preferences.Get("Login", "")))
            {

            }
            else
            {
                NeedAuthorized();
            }
        }
        public async void AddToFavorites(Product product)
        {
            if (!string.IsNullOrWhiteSpace(Preferences.Get("Login", "")))
            {
                var addAction = await restAPIService.AddProductToFavorite(new Favorite
                {
                    ProductId = product.IdProduct,
                    UserId = Preferences.Get("id_user", 0)
                });
                if(addAction == true)
                {
                    ShowSnackBar("Товар добавлен в избранное");
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
