using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        public AppliancesStoreDbContext context { get; set; }
        public BasketController()
        {
            context = new AppliancesStoreDbContext();
        }
       // [HttpGet("GetBasket")]
       // public List<Products> GetProducts()
    }
}
