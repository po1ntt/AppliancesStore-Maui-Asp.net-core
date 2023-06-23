using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class ProductsAboutViewModel : BaseVM
    {
        private Product _Product;

        public Product Product
        {
            get { return _Product; }
            set { _Product = value;
                OnPropertyChanged();
            }
        }
      
        public ProductsAboutViewModel(Product product)
        {
            Product = product;
        }
    }
}
