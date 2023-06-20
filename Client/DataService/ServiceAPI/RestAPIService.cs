using Client.DataService.Constants;
using Client.DataService.SpecialModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Client.DataService.DboModels;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Client.DataService.ServiceAPI
{
    public class RestAPIService : IRestAPIService
    {
        public HttpClient httpclient;
        public readonly string Adress;
        public readonly JsonSerializerOptions jsonSerializerOptions;

        public RestAPIService()
        {
            httpclient = new HttpClient();
            Adress = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.0.114:5067" : "http://192.168.0.114:5067";
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task<bool> AddProductToFavorite(Favorite favorite)
        {
            var stringContent = new StringContent(favorite.ToString());
            var response = await httpclient.PostAsJsonAsync(UrlsApi.ADDPRODUCTTOFAVORITE_URL, favorite);
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteProductFromBasket(Basket basket)
        {
            var response = await httpclient.DeleteAsync(UrlsApi.DeleteFromBasketProduct(basket.UserId, basket.ProductId));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductFromFavorite(int id_product)
        {
            var response = await httpclient.DeleteAsync(UrlsApi.DeleteFromFavoriteProduct(Preferences.Default.Get("id_user", 0), id_product));
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Brand>> GetBrands()
        {
            var collection = await httpclient.GetFromJsonAsync(UrlsApi.GETBRANDS_URL, typeof(List<Brand>), jsonSerializerOptions);
            return collection as List<Brand>;
        }

        public async Task<List<Category>> GetCategories()
        {
            var collection = await httpclient.GetFromJsonAsync(UrlsApi.GETCATEGOTIES_URL, typeof(List<Category>), jsonSerializerOptions);
            return collection as List<Category>;
        }

        public async Task<List<Product>> GetProductsByBrand(int id_brand)
        {
            var collection = await httpclient.GetFromJsonAsync(UrlsApi.ProductByBrand(id_brand), typeof(List<Product>), jsonSerializerOptions);
            return collection as List<Product>;
        }

        public async Task<List<Product>> GetProductsByCategory(int id_category)
        {
            var collection = await httpclient.GetFromJsonAsync(UrlsApi.ProductByCategory(id_category), typeof(List<Product>), jsonSerializerOptions);
            return collection as List<Product>;
        }

        public Task<List<Product>> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateCountProductInBasket(Basket basket, string action)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (action == "plus")
            {
               await httpclient.PutAsJsonAsync(UrlsApi.UpdateProductCntPlus_URL, basket);
            }
            else
            {
                if (basket.CountProduct > 1)
                {
                     await httpclient.PutAsJsonAsync(UrlsApi.UpdateProductCntPlus_URL, basket);
                    return "MinusAction";
                }
                else
                {
                     await httpclient.DeleteAsync(UrlsApi.DeleteFromBasketProduct(basket.UserId, basket.ProductId));
                    return "DeleteAction";
                }
            }
            return "PlusAction";
           
        }

        public Task<bool> AddReviewToProduct(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetReviewsToProduct(int id_product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductAndCategoryModel>> GetProductAndCategoryModels()
        {
            try
            {
                var collection = await httpclient.GetFromJsonAsync(UrlsApi.GETPRODUCTSANDCATEGORY_URL, typeof(List<ProductAndCategoryModel>), jsonSerializerOptions) as List<ProductAndCategoryModel>;

                foreach (var model in collection.ToList())
                {
                    if (model.products.Count == 0)
                    {
                        collection.Remove(model);
                    }
                }
                return collection;
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка", ex.Message, "Ок");
                return new List<ProductAndCategoryModel>();
            }
          

        }

        public async Task<bool> AuhtorizeUser(string login, string password)
        {
           var response = await httpclient.GetAsync(UrlsApi.AuthorizeUser(login, password));
            var responseContent = await response.Content.ReadAsStringAsync();
            var user =JsonConvert.DeserializeObject<User>(responseContent);
            Preferences.Default.Set("id_user", user.IdUser);
            return response.IsSuccessStatusCode;
        }

        public Task<User> RegistUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetUserFavorites()
        {
            var collection = await httpclient.GetFromJsonAsync(UrlsApi.FavoritesUser(Preferences.Default.Get("id_user", 0)), typeof(List<Product>), jsonSerializerOptions) as List<Product>;
            return collection;
        }



        public async Task<bool> AddProductToBasket(Basket basket)
        {
            var response = await httpclient.PostAsJsonAsync(UrlsApi.ADDPRODUCTTOBASKT_URL, basket);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Basket>> GetUserBasketById()
        {
            var collection = await httpclient.GetFromJsonAsync(UrlsApi.BasketUser(Preferences.Default.Get("id_user", 0)), typeof(List<Basket>), jsonSerializerOptions) as List<Basket>;
            return collection;
        }
    }
}
