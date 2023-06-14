using Client.DataService.SpecialModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataService.DboModels;

namespace Client.DataService.ServiceAPI
{
    public interface IRestAPIService
    {
        Task<bool> AuhtorizeUser(string login, string password);
        Task<User> RegistUser(string login, string password);
        Task<List<Product>> GetUserFavorites();
        Task<List<Product>> GetUserBasket();
        Task<List<Category>> GetCategories();
        Task<List<Brand>> GetBrands();
        Task<List<Product>> GetProductsByCategory(int id_category);
        Task<List<Product>> GetProductsByBrand(int id_brand);
        Task<List<Product>> GetProductsByName(string name);
        Task<List<ProductAndCategoryModel>> GetProductAndCategoryModels();
        Task<bool> DeleteProductFromBasket(Basket basket);
        Task<bool> UpdateCountProductInBasket(Basket basket, string action);
        Task<bool> AddProductToFavorite(Favorite favorite);
        Task<bool> AddProductToBasket(Basket basket);
        Task<bool> DeleteProductFromFavorite(Favorite favorite);
        Task<bool> AddReviewToProduct(Review review);
        Task<bool> GetReviewsToProduct(int id_product);
       
    }
}
