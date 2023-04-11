using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

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
        public async Task<List<Users>> GetUsersAsync() => await context.Users.Include(p=> p.PostponedProduct).ThenInclude(p=> p.Products).Include(p => p.Basket).ThenInclude(p=>p.Products).ToListAsync();

        [HttpGet("GetUserByData")]
        public async Task<Users?> GetUsersByData(string phone, string password) => await context.Users
            .Include(p => p.PostponedProduct)
                .ThenInclude(p => p.Products)
                .ThenInclude(p=> p.ReviewsProduct)
            .Include(p => p.Basket)
                .ThenInclude(p => p.Products)
                .ThenInclude(p=>p.ReviewsProduct)
            .FirstOrDefaultAsync(p=> p.userPhone == phone && p.UserPasswod == password);

        [HttpGet("GetPostPoned")]
        public async Task<List<PostponedProduct>> GetPostponedProductsAsync(int id_user)
            => await context.PostponedProduct
            .Where(p => p.user_id == id_user)
                .Include(p=> p.Products.BrandProduct)
                .Include(p=> p.Products.Subcategory)
            .ToListAsync();
        [HttpGet("GetRecentlyViewed")]
        public async Task<List<RecentlyViewed>> GetRecentlyViewedProductsAsync(int id_user)
           => await context.RecentlyViewed
           .Where(p => p.user_id == id_user)
               .Include(p => p.Products.BrandProduct)
               .Include(p => p.Products.Subcategory)
           .ToListAsync();
    }
}
