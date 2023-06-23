using Client.DataService;
using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class FavoritesViewModel : BaseVM
    {
        public List<Product> products1 { get; set; } = new List<Product>();
        private string _SearchValue;

        public string SearchValue
        {
            get { return _SearchValue; }
            set
            {
                _SearchValue = value;
                OnPropertyChanged();
                FilterByName();
            }
        }
        public void FilterByName()
        {
            products1 = StaticValues.Favorites;

            if (!string.IsNullOrWhiteSpace(SearchValue))
            {
                FavoritesList.Clear();
                foreach (var product in products1.Where(p => p.ProductName.ToLower().Contains(SearchValue.ToLower())).ToList())
                {
                    if (StaticValues.Favorites.Any(a => a.IdProduct == product.IdProduct))
                    {
                        product.IsFavorite = "1";
                    }
                    else
                    {
                        product.IsFavorite = "0";
                    }
                    if (StaticValues.Basket.Any(a => a.ProductId == product.IdProduct))
                    {
                        product.IsBasket = "1";
                    }
                    else
                    {
                        product.IsBasket = "0";
                    }
                    FavoritesList.Add(product);
                }
            }
            else
            {
                FavoritesList.Clear();
                foreach (var product in products1)
                {
                    if (StaticValues.Favorites.Any(a => a.IdProduct == product.IdProduct))
                    {
                        product.IsFavorite = "1";
                    }
                    else
                    {
                        product.IsFavorite = "0";
                    }
                    if (StaticValues.Basket.Any(a => a.ProductId == product.IdProduct))
                    {
                        product.IsBasket = "1";
                    }
                    else
                    {
                        product.IsBasket = "0";
                    }
                    FavoritesList.Add(product);
                }
            }

        }
        public ObservableCollection<Product>  FavoritesList { get; set; }
        public Command DeleteFromFavoritesCommand {get ; set;}
        public Command ApperingCommand { get; set;}
        public Command OutFromAccount { get; set; }
        public FavoritesViewModel()
        {
            FavoritesList = new ObservableCollection<Product>();
            DeleteFromFavoritesCommand = new Command((object args) => DeleteFromFavorite(args as Product));
            ApperingCommand = new Command((object args) => Init());
            OutFromAccount = new Command((object args) => OutAccount());

        }
        public async void Init()
        {
            if (!string.IsNullOrWhiteSpace(Preferences.Default.Get("Login", "")))
            {
                if (StaticValues.Favorites.Count == 0)
                {
                    StaticValues.Favorites = await restAPIService.GetUserFavorites();
                }
            }
            FavoritesList.Clear();
            foreach (var item in StaticValues.Favorites)
            {
                if (StaticValues.Basket.Any(a => a.ProductId == item.IdProduct))
                {
                    item.IsBasket = "1";
                }
                else
                {
                    item.IsBasket = "0";
                }
                FavoritesList.Add(item);

            }


        }
        public async void OutAccount()
        {
            bool answer = await Shell.Current.DisplayAlert("Выход из аккаунта", "Вы действительно хотите выйти из аккаунта?", "Да", "Нет");
            if (answer)
            {
                Preferences.Default.Clear();
                Init();
            }

        }
        public async void DeleteFromFavorite(Product product)
        {
            
                var addAction = await restAPIService.DeleteProductFromFavorite(product.IdProduct);
                if (addAction == true)
                {
                    ShowSnackBar("Товар удален из избранного");
                    StaticValues.Favorites.Remove(product);
                    FavoritesList.Remove(product);
                }
            
        }
      

    }
}
