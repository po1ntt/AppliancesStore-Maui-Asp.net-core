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
       public ObservableCollection<Product>  FavoritesList { get; set; }
        public Command DeleteFromFavoritesCommand {get ; set;}
        public Command ApperingCommand { get; set;}
        public FavoritesViewModel()
        {
            FavoritesList = new ObservableCollection<Product>();
            DeleteFromFavoritesCommand = new Command((object args) => DeleteFromFavorite(args as Product));
            ApperingCommand = new Command((object args) => Init());
        }
        public void Init()
        {
            FavoritesList.Clear();
            foreach (var item in StaticValues.Favorites)
            {
                FavoritesList.Add(item);
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
