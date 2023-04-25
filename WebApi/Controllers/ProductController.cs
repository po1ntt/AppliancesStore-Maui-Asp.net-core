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
        public AppliancesStoreDbContext context { get; set; }
        public ProductController()
        {
            context = new AppliancesStoreDbContext();
        }
        [HttpGet("GetProducts")]
        public async Task<List<Products>> GetProducts() => await context.Products.Include(p=> p.ReviewsProduct).Include(p=> p.Subcategory).ToListAsync();

        [HttpGet("GetCharacteristicProduct")]
        public List<CharacteristicProduct> GetCharacteristicProduct(int id_product) => context.CharacteristicProduct.Where(p=> p.product_id == id_product).Include(p => p.Character).ToList();
        [HttpGet("GetReviewsProduct")]

        public List<ReviewsProduct> GetReviewsProduct(int id_product) => context.ReviewsProduct.Where(p => p.product_id == id_product).ToList();


    }
}
