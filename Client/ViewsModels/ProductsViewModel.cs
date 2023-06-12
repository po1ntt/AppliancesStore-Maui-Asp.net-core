using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataService.DboModels;

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
        public Category Category { get; set; }
        public Command RefreshCommand { get; set; }
        public ProductsViewModel(Category category)
        {
            Products = new List<Product>();
            Category = category;
            RefreshCommand = new Command((object args) => Init());
            Init();
        }
        public async void Init()
        {
            try
            {
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
                    Products = await restAPIService.GetProductsByCategory(Category.IdCategory);
                }
                IsBusy = false;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
