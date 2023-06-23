using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataService;
using Client.DataService.DboModels;
using Mopups.Services;

namespace Client.ViewsModels
{
    public class ProductsViewModel : BaseVM
    {
        public List<Product> products1 = new List<Product>();
        public ObservableCollection<Product> Products { get; set; } 
        private string _TitlePage;

        public string TitlePage
        {
            get { return _TitlePage; }
            set { _TitlePage = value;
                OnPropertyChanged();
            }
        }
        private string _SearchValue;

        public string SearchValue
        {
            get { return _SearchValue; }
            set { _SearchValue = value;
                OnPropertyChanged();
                FilterByName();
            }
        }

        public Brand Brand { get; set; } 
        public Category Category { get; set; }
        public Command RefreshCommand { get; set; }
        public ProductsViewModel(Brand brand)
        {
            Products = new ObservableCollection<Product>();

            Brand = brand;
            Category = null;
            TitlePage = brand.NameBrand;
            RefreshCommand = new Command((object args) => Init());
            Init();
        }
        public ProductsViewModel(Category category)
        {
            Products = new ObservableCollection<Product>();
            Category = category;
            TitlePage = category.Name;

            Brand = null;
            RefreshCommand = new Command((object args) => Init());
            Init();
        }
        public async void Init()
        {
            try
            {
                ShowLoadingPopup();
                IsBusy = true;
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                {
                    var result = await Shell.Current.DisplayActionSheet("Не стабильное интернет соединение", null, null, "Обновить");
                    if (result == "Обновить")
                    {
                        Init();
                    }
                }
                else
                {
                    Products.Clear();

                    List<Product> products = new List<Product>();

                    if (Brand != null)
                    {
                        products = await restAPIService.GetProductsByBrand(Brand
                            .IdBrand);
                    }
                    else
                    {
                       products = await restAPIService.GetProductsByCategory(Category.IdCategory);

                    }
                    foreach (var product in products)
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
                        Products.Add(product);

                    }
                    products1 = products;
   
                }
                IsBusy = false;
                await MopupService.Instance.PopAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public void FilterByName()
        {
            if (!string.IsNullOrWhiteSpace(SearchValue)) 
            {
                Products.Clear();
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
                    Products.Add(product);
                }
            }
            else
            {
                Products.Clear();
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
                    Products.Add(product);
                }
            }
          
        }
    }
}
