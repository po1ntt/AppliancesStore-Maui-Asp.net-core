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
        public Task<bool> AddProductToFavorite(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductFromBasket(Basket basket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductFromFavorite(Favorite favorite)
        {
            throw new NotImplementedException();
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

        public async Task<bool> UpdateCountProductInBasket(Basket basket, string action)
        {
            var stringContent = new StringContent(basket.ToString());
            HttpResponseMessage response = new HttpResponseMessage();
            if(action == "plus")
                response = await httpclient.PutAsync(UrlsApi.UpdateProductCntPlus_URL, stringContent);
            else
            {
                if(basket.CountProduct > 1)
                    response = await httpclient.PutAsync(UrlsApi.UpdateProductCntPlus_URL, stringContent);
                else
                    response = await httpclient.DeleteAsync(UrlsApi.RemoveProductFromBasket(basket.IdBasket));
            }
            return response.IsSuccessStatusCode;
           
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
            var collection = await httpclient.GetFromJsonAsync(UrlsApi.GETPRODUCTSANDCATEGORY_URL, typeof(List<ProductAndCategoryModel>), jsonSerializerOptions) as List<ProductAndCategoryModel>;
           
            foreach(var model in collection.ToList())
            {
                if(model.products.Count == 0)
                {
                    collection.Remove(model);
                }
            }
            return collection;
        }
    }
}
