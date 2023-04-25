using Client.DataService;
using Client.Models;
using Client.Views.Templates.ProductsTemplate;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class HomeVM : BaseVM
    {
        public ObservableCollection<Subcategory> SubCategories { get; set; } = new();

        public ObservableCollection<ProductModel> productsDay { get; set; } = new();
        public ObservableCollection<ProductModel> productsNew { get; set; } = new();
        public ObservableCollection<ProductModel> productsTrend { get; set; } = new();

        public  void InitAsunc()
        {
            GetSubCategories();
            GetProductsDay();
            GetNewProducts();
            GetTrendProducts();
        }
        public async void GetSubCategories()
        {
            List<Subcategory> subcategories = await DataService.CategoryService.categoryService.GetSubCategories();
            foreach(var item in subcategories)
            {
                SubCategories.Add(item);
            }
        }
        public async void GetProductsDay()
        {
            List<ProductModel> products = await ProductService.productService.ConvertProductsToModel();
            productsDay.Clear();
            foreach (var item in products)
            {
                productsDay.Add(item);
            }
        }
        public async void GetNewProducts()
        {
            List<ProductModel> products = await ProductService.productService.ConvertProductsToModel();
            productsNew.Clear();
            foreach (var item in products.Where(p => p.ProductData.isNew == true))
            {
                productsNew.Add(item);
            }
        }
        public async void GetTrendProducts()
        {
            List<ProductModel> products = await ProductService.productService.ConvertProductsToModel();
            productsTrend.Clear();
            foreach (var item in products.Where(p => p.ProductData.isTrend == true))
            {
                productsTrend.Add(item);
            }
        }
        public HomeVM()
        {
            InitAsunc();
            
        }
       
    }
}
