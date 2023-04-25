using Client.DataService;
using Client.Models;
using Client.Views.Templates.ProductsTemplate;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public partial class ProductsVM : BaseVM
    {
        private string _FilterName;

        public string FilterName
        {
            get { return _FilterName; }
            set { _FilterName = value;
                FilterByName(_FilterName);
                OnPropertyChanged();
            }
        }
        private Subcategory _SubCategorySelected;

        public Subcategory SubCategorySelected
        {
            get { return _SubCategorySelected; }
            set
            {
                _SubCategorySelected = value;
                OnPropertyChanged();
            }
        }

        public ProductsVM(string name)
        {
            LoadProductList(name);
        }
        public ProductsVM(Subcategory subcategory)
        {
            LoadProductList(subcategory);
            _SubCategorySelected = subcategory;
        }
        public ObservableCollection<ProductModel> productsList { get; set; } = new();
        public async void LoadProductList(Subcategory subcategory)
        {
            List<ProductModel> products = await ProductService.productService.ConvertProductsToModel();
            productsList.Clear();
            foreach (var item in products.Where(p => p.ProductData.subcategory.nameSubCategory == subcategory.nameSubCategory).ToList())
            {
                productsList.Add(item);
            }
        }
        public async void LoadProductList(string name)
        {
            List<ProductModel> products = await ProductService.productService.ConvertProductsToModel();
            productsList.Clear();
            foreach (var item in products.Where(p => p.ProductData.productsName.ToLower().Contains(name.ToLower())).ToList())
            {
                productsList.Add(item);
            }
        }
        public  void FilterByName(string name)
        {
            List<ProductModel> products = productsList.ToList();
            productsList.Clear();
            foreach (var item in products.Where(p => p.ProductData.productsName.ToLower().Contains(name.ToLower())).ToList())
            {
                productsList.Add(item);
            }
        }

    }
}
