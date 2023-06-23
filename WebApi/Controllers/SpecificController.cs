using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificController : ControllerBase
    {
        public class ProductsAndCategoryInfo
        {
            public string? NameCategory { get; set; }
            public List<Product>? Products { get; set; }
        }
        private AppliancesStoreContext appliancesStoreContext { get; set; }
        public SpecificController()
        {
            appliancesStoreContext = new AppliancesStoreContext();
        }
        [HttpGet("GetBrands")]
        public async Task<List<Brand>> GetBrands()
        {
            var collection = new List<Brand>();
            collection = await appliancesStoreContext.Brands.ToListAsync();
            return collection;
        }
        [HttpGet("GetPaymentMethods")]
        public async Task<List<PaymentMethod>> GetPaymentMethods()
        {
            var collection = new List<PaymentMethod>();
            collection = await appliancesStoreContext.PaymentMethod.ToListAsync();
            return collection;
        }
        [HttpGet("GetCategory")]
        public async Task<List<Category>> GetCategory()
        {
            var collection = new List<Category>();
            collection = await appliancesStoreContext.Categories.ToListAsync();
            return collection;
        }

        [HttpGet("GetCategoryAndProducts")]
        public async Task<List<ProductsAndCategoryInfo>> GetCategoryAndProducts()
        {
            var CategoryAndProducts = new List<ProductsAndCategoryInfo>();
            var collection = await appliancesStoreContext.Categories.Include(p=> p.Products).ThenInclude(p=> p.ProductBrand).ToListAsync();
            foreach(var item in collection)
            {
                foreach(var product in item.Products)
                {
                    if (product.Reviews.Count != 0)
                    {
                        product.CountReviews = product.Reviews.Count();
                        product.AvgGrade = product.Reviews.Average(p => p.Grade);
                    }

                }
                CategoryAndProducts.Add(new ProductsAndCategoryInfo()
                {
                    NameCategory = item.Name,
                    Products = item.Products.ToList()
                });
            }
            return CategoryAndProducts;
        }
        [HttpPost("AddNewCategory")]
        public IActionResult AddNewCategory(Category category)
        {
            if (category == null)
                return BadRequest();
            appliancesStoreContext.Categories.Add(category);
            appliancesStoreContext.SaveChanges();
            return Ok();
        }
        [HttpPost("AddNewBrand")]
        public IActionResult AddNewBrand(Brand brand)
        {
            if (brand == null)
                return BadRequest();
            appliancesStoreContext.Brands.Add(brand);
            appliancesStoreContext.SaveChanges();
            return Ok();
        }
    }
}
