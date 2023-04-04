using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public AppliancesStoreDbContext context { get; set; }
        public CategoryController()
        {
            context = new AppliancesStoreDbContext();
        }
        [HttpGet("GetCategories")]
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await context.Category.Include(p=> p.Subcategories).ToListAsync();
        }
    }
}
