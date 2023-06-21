using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public AppliancesStoreContext appliancesStoreContext { get; set; }
        public OrderController()
        {
            appliancesStoreContext = new AppliancesStoreContext();
        }
        [HttpGet("GetOrders")]
        public async Task<List<Order>> GetOrders(int userid)
        {
            var collection = new List<Order>();
            collection = await appliancesStoreContext.Orders.Include(p => p.OrderedProducts).Include(p=>p.Status).Where(p => p.UserId == userid).ToListAsync();
            return collection;
        }
    }
}
