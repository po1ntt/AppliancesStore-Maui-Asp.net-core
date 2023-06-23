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
            collection = await appliancesStoreContext.Orders.Include(p => p.OrderedProducts).ThenInclude(p=> p.Product).Include(p=>p.Status).Include(p=> p.PaymentMethod).Where(p => p.UserId == userid).ToListAsync();
            return collection;
        }
        [HttpPost("AddNewOrder")]
        public async Task<bool> AddNewOrder(Order order)
        {
            try
            {
                appliancesStoreContext.Orders.Add(new Order()
                {
                    OrderNumber = order.OrderNumber,
                    FirstNameReceiver = order.FirstNameReceiver,
                    SecondNameReceiver = order.SecondNameReceiver,
                    PatronymicReceiver = order.PatronymicReceiver,
                    Comment = order.Comment,
                    StatusId = 1,
                    UserId = order.UserId,
                    AdressReceiver = order.AdressReceiver,
                    DateOrderBegin = DateTime.Today.ToString("d"),
                    PaymentId = order.PaymentId
                    
                });
                await appliancesStoreContext.SaveChangesAsync();
                var thatOrder = appliancesStoreContext.Orders.FirstOrDefault(p=>p.OrderNumber == order.OrderNumber);
                if (thatOrder != null)
                {
                    foreach(var item in order.OrderedProducts)
                    {
                        appliancesStoreContext.OrderedProducts.Add(new OrderedProduct()
                        {
                            orderId = thatOrder.IdOrder,
                            ProductId = item.ProductId,
                            CountProduct = item.CountProduct
                        });
                        await appliancesStoreContext.SaveChangesAsync();

                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
           
        }
        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(int id_order)
        {

            var orderToRemove = appliancesStoreContext.Orders.FirstOrDefault(p => p.IdOrder == id_order);
            if (orderToRemove == null)
                return BadRequest();
            appliancesStoreContext.Orders.Remove(orderToRemove);
            appliancesStoreContext.SaveChanges();
            return Ok();
        }

    }
}
