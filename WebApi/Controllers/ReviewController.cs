using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private AppliancesStoreContext appliancesStoreContext { get; set; }
        public ReviewController()
        {
            appliancesStoreContext = new AppliancesStoreContext();
        }
        [HttpGet("GetProductReviews")]
        public async Task<List<Review>> GetReviewsAsync(int id_product)
        {
            var collection = new List<Review>();
            collection = await appliancesStoreContext.Reviews.Where(p => p.ProductId == id_product).ToListAsync();
            return collection;
        } 
    }
}
