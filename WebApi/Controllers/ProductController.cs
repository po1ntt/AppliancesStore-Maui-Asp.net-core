using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private AppliancesStoreContext appliancesStoreContext { get; set; }
        public ProductController()
        {
            appliancesStoreContext = new AppliancesStoreContext();
        }
        [HttpGet("GetProductByCategory")]
        public async Task<List<Product>> GetProductByCategory(int id_category)
        {
            var collection = new List<Product>();
            collection = await appliancesStoreContext.Products.Include(p => p.Reviews).Include(p => p.ProductBrand).Include(p => p.ProductCategory).Where(p => p.ProductCategoryId == id_category).ToListAsync();
            foreach (var item in collection)
            {
                if (item.Reviews.Count != 0)
                {
                    item.CountReviews = item.Reviews.Count();
                    item.AvgGrade = item.Reviews.Average(p => p.Grade);
                }

            }
            return collection;
        }
        [HttpGet("GetProductsByBrand")]
        public async Task<List<Product>> GetProductsByBrand(int id_brand)
        {
            var collection = new List<Product>();
            collection = await appliancesStoreContext.Products.Include(p=> p.Reviews).Include(p=> p.ProductBrand).Include(p=> p.ProductCategory).Where(p => p.ProductBrandId == id_brand).ToListAsync();
            foreach(var item in collection)
            {
                if(item.Reviews.Count != 0)
                {
                    item.CountReviews = item.Reviews.Count();
                    item.AvgGrade = item.Reviews.Average(p => p.Grade);
                }
      
            }
            return collection;
        }
        [HttpPost("AddNewProduct")]
        public IActionResult AddNewProduct(Product product)
        {
            if (product == null)
                return BadRequest();
            appliancesStoreContext.Products.Add(new Product()
            {
                ProductBrandId = product.ProductBrandId,
                ProductName = product.ProductName,
                ProductDescription= product.ProductDescription,
                ProductCategoryId = product.ProductCategoryId,
                ProductImage = product.ProductImage
            });
            appliancesStoreContext.SaveChanges();
            return Ok();
        }
        [HttpPost("AddProductToFavorite")]
        public IActionResult ProductToFavorite(Favorite favorite)
        {
            if (favorite == null)
                return BadRequest();
            appliancesStoreContext.Favorites.Add(favorite);
            appliancesStoreContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("DeleteProductFromFavorite")]
        public IActionResult DeleteProductFromFavorite(int id_favorite)
        {
            var favoriteToDelete = appliancesStoreContext.Favorites.FirstOrDefault(p => p.IdFavorites == id_favorite);
            if (favoriteToDelete == null)
                return BadRequest();
            appliancesStoreContext.Favorites.Remove(favoriteToDelete);
            appliancesStoreContext.SaveChanges();
            return Ok();
        }

    }
}
