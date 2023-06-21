using System;
using System.Collections.Generic;
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
        
        private List<Product> _Products;

        public List<Product> Products
        {
            get { return _Products; }
            set { _Products = value;
                OnPropertyChanged();
            }
        }
        private string _TitlePage;

        public string TitlePage
        {
            get { return _TitlePage; }
            set { _TitlePage = value;
                OnPropertyChanged();
            }
        }

        public Brand Brand { get; set; } 
        public Category Category { get; set; }
        public Command RefreshCommand { get; set; }
        public ProductsViewModel(Brand brand)
        {
            Brand = brand;
            Category = null;
            TitlePage = brand.NameBrand;
            RefreshCommand = new Command((object args) => Init());
            Init();
        }
        public ProductsViewModel(Category category)
        {
            Products = new List<Product>();
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
                    }
                    Products = products;
                }
                IsBusy = false;
                await MopupService.Instance.PopAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
