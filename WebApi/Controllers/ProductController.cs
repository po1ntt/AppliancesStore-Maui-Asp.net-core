using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.ModelsToClient;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public AppliancesStoreDbContext context { get; set; }
        public ProductController()
        {
            context = new AppliancesStoreDbContext();
        }
        [HttpGet("GetProducts")]
        public async Task<List<Products>> GetProducts() => await context.Products.Include(p=> p.ReviewsProduct).Include(p=> p.Subcategory).ToListAsync();
        [HttpGet("GetProductsBySubCategory")]
        public async Task<List<ProductModel>> GetProductsBySubCategory(int id_subcategory) 
        {
            var result = new List<ProductModel>();
            try
            {
                var products = await context.Products.Include(p => p.ReviewsProduct).Where(p => p.Subcategory_id == id_subcategory).ToListAsync();
                foreach (var item in products)
                {
                    var itemProduct = new ProductModel();
                    itemProduct.id_product = item.id_products;
                    itemProduct.Price = item.Price;
                    itemProduct.ProductDescription = item.ProductsDesсription;
                    if (item.ReviewsProduct.Count > 0)
                    {
                        itemProduct.AvgGrade = item.ReviewsProduct.Average(p => p.Grade);
                    }
                    itemProduct.CountReviews = item.ReviewsProduct.Count;
                    itemProduct.NameProduct = item.ProductsName;
                    itemProduct.Quantity = item.Quantity;
                    itemProduct.IsNew = item.IsNew;
                    itemProduct.IsTrend = item.IsTrend;
                    itemProduct.ImageUrl = item.ProductImageUrl;
                    result.Add(itemProduct);
                }
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("GetProductsBySearch")]
        public async Task<List<ProductModel>> GetProductsBySearch(string searchText)
        {
            var result = new List<ProductModel>();
            try
            {
                var products = await context.Products.Include(p => p.ReviewsProduct).Where(p => p.ProductsName.ToLower().Contains(searchText.ToLower())).ToListAsync();
                foreach (var item in products)
                {
                    var itemProduct = new ProductModel();
                    itemProduct.id_product = item.id_products;
                    itemProduct.Price = item.Price;
                    itemProduct.ProductDescription = item.ProductsDesсription;
                    if (item.ReviewsProduct.Count > 0)
                    {
                        itemProduct.AvgGrade = item.ReviewsProduct.Average(p => p.Grade);
                    }
                    itemProduct.CountReviews = item.ReviewsProduct.Count;
                    itemProduct.NameProduct = item.ProductsName;
                    itemProduct.Quantity = item.Quantity;
                    itemProduct.IsNew = item.IsNew;
                    itemProduct.IsTrend = item.IsTrend;
                    itemProduct.ImageUrl = item.ProductImageUrl;
                    result.Add(itemProduct);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetCharacteristicProduct")]
        public List<CharacteristicProduct> GetCharacteristicProduct(int id_product) => context.CharacteristicProduct.Where(p=> p.product_id == id_product).Include(p => p.Character).ToList();
        [HttpGet("GetReviewsProduct")]

        public List<ReviewsProduct> GetReviewsProduct(int id_product) => context.ReviewsProduct.Where(p => p.product_id == id_product).Include(p=> p.Users).ToList();


    }
}
