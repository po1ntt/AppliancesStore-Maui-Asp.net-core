using Client.Models;
using Client.Views.Templates.ProductsTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.DataService
{
    public class ProductService : BaseService
    {
        public static ProductService productService = new ProductService();
        public async Task<List<Products>> GetProducts()
        {
            List<Products> Productes = new();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("500");
                return Productes;
            }
            try
            {

                HttpResponseMessage response = await httpclient.GetAsync($"{Adress}/api/Product/GetProducts");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Productes = JsonSerializer.Deserialize<List<Products>>(data, jsonSerializerOptions);
                }
                else
                {
                    Console.WriteLine("400");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Productes;
            }
            return Productes;
        }
        public async Task<List<ProductModel>> ConvertProductsToModel()
        {
            List<ProductModel> Productes = new();
           
            try
            {
                foreach(var product in await GetProducts())
                {
                    double avgGrade = 0;

                    if (product.reviewsProduct.Count != 0)
                    {
                        avgGrade = product.reviewsProduct.Average(p => p.grade);

                    }
                 
                    bool isFavorite = false;
                    bool isBasket = false;
                   
                    if (UsersService.UserInfo != null)
                    {
                        if(UsersService.usersService.basketUser.Count != 0)
                        {
                            foreach(var item in UsersService.usersService.basketUser)
                            {
                                if(item.products.id_products == product.id_products)
                                {
                                    isBasket = true;
                                }
                            }
                        }
                        if (UsersService.usersService.postponedProducts.Count != 0)
                        {
                            foreach (var item in UsersService.usersService.postponedProducts)
                            {
                                if (item.products.id_products == product.id_products)
                                {
                                    isFavorite = true;
                                }
                            }
                        }
                    }
                    Productes.Add(new ProductModel()
                    {
                        ProductData = product,
                        AvgGrade = avgGrade,
                        IsFavorite = isFavorite,
                        IsInBasket = isBasket
                       
                    });
                }
                return Productes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Productes;
            }
        }
       
    }
}
