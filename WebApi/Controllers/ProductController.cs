using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public List<Products> GetProducts() => context.Products.ToList();
        
    }
}
