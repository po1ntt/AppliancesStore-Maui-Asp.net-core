using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApi.Models;
using WebApi.Models.ModelsToClient;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public AppliancesStoreDbContext context { get; set; }
        public UsersController()
        {
            context = new AppliancesStoreDbContext();
        }
        [HttpGet("GetUsers")]
        public async Task<List<Users>> GetUsersAsync() => await context.Users.ToListAsync();

        [HttpGet("GetUserByData")]
        public async Task<Users?> GetUsersByData(string phone, string password) => await context.Users.FirstOrDefaultAsync(p=> p.userPhone == phone && p.UserPasswod == password);

        [HttpGet("GetPostPoned")]
        public async Task<List<ProductModel>> GetPostponedProductsAsync(int id_user)
        {
            var result = new List<ProductModel>();
            try
            {
                var products = await context.PostponedProduct.Include(p=> p.Products.ReviewsProduct).Where(p => p.user_id == id_user).ToListAsync();
                foreach(var item in products)
                {
                    var itemProduct = new ProductModel();
                    itemProduct.id_product = item.Products.id_products;
                    itemProduct.Price = item.Products.Price;
                    itemProduct.ProductDescription = item.Products.ProductsDesсription;
                    if(item.Products.ReviewsProduct.Count > 0)
                    {
                        itemProduct.AvgGrade = item.Products.ReviewsProduct.Average(p => p.Grade);
                    }
                    itemProduct.CountReviews = item.Products.ReviewsProduct.Count;
                    itemProduct.NameProduct = item.Products.ProductsName;
                    itemProduct.Quantity = item.Products.Quantity;
                    itemProduct.IsNew = item.Products.IsNew;
                    itemProduct.ImageUrl = item.Products.ProductImageUrl;
                    itemProduct.IsTrend = item.Products.IsTrend;
                    result.Add(itemProduct);
                }
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
      
        [HttpGet("GetBasket")]
        public async Task<List<ProductModel>> GetBasket(int id_user)
        {
            var result = new List<ProductModel>();
            try
            {
                var products = await context.Basket.Include(p => p.Products.ReviewsProduct).Where(p => p.user_id == id_user).ToListAsync();
                foreach (var item in products)
                {
                    var itemProduct = new ProductModel();
                    itemProduct.id_product = item.Products.id_products;
                    itemProduct.Price = item.Products.Price;
                    itemProduct.ProductDescription = item.Products.ProductsDesсription;
                    if (item.Products.ReviewsProduct.Count > 0)
                    {
                        itemProduct.AvgGrade = item.Products.ReviewsProduct.Average(p => p.Grade);
                    }
                    itemProduct.CountReviews = item.Products.ReviewsProduct.Count;
                    itemProduct.NameProduct = item.Products.ProductsName;
                    itemProduct.Quantity = item.Products.Quantity;
                    itemProduct.IsNew = item.Products.IsNew;
                    itemProduct.IsTrend = item.Products.IsTrend;
                    itemProduct.ImageUrl = item.Products.ProductImageUrl;
                    result.Add(itemProduct);
                }
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
