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
        Task<bool> AddNewOrder(Order order);
        Task<bool> AuhtorizeUser(string login, string password);
        Task<bool> RegistUser(User user);
        Task<List<Product>> GetUserFavorites();
        Task<List<Basket>> GetUserBasketById();
        Task<List<PaymentMethod>> GetPaymentMethods();
        Task<List<Order>> GetOrders();
        Task<List<Category>> GetCategories();
        Task<List<Brand>> GetBrands();
        Task<List<Product>> GetProductsByCategory(int id_category);
        Task<List<Product>> GetProductsByBrand(int id_brand);
        Task<List<ProductAndCategoryModel>> GetProductAndCategoryModels();
        Task<bool> DeleteProductFromBasket(Basket basket);
        Task<string> UpdateCountProductInBasket(Basket basket, string action);
        Task<bool> AddProductToFavorite(Favorite favorite);
        Task<bool> AddProductToBasket(Basket basket);
        Task<bool> DeleteProductFromFavorite(int id_product);
        Task<bool> DeletOrder(int id_order);
  
       
    }
}
