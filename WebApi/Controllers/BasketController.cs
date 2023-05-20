using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
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
        public class BasketParams
        {
            public string? action { get; set; }
            public int product_id { get; set; }
            public int user_id { get; set; }

        }
        [HttpPost("AddProductToBasket")]
        public async Task<bool> addProductToBasket([FromBody]BasketParams basket)
        {
            try
            {
                context.Basket.Add(new Basket
                {
                    product_id = basket.product_id,
                    AmountProduct = 1,
                    user_id = basket.user_id

                });
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
          
        }
     
        [HttpPut("BasketPlusMinus")]
        public async Task<bool> BasketPlusMinus([FromBody]BasketParams basketAction)
        {
            try
            {
                Basket? baskettoupdate = context.Basket.FirstOrDefault(p=> p.product_id== basketAction.product_id);
                if(baskettoupdate !=null)
                {
                    if (basketAction.action == "plus")
                    {
                        baskettoupdate.AmountProduct++;
                        await context.SaveChangesAsync();

                        return true;

                    }
                    else
                    {
                        baskettoupdate.AmountProduct--;
                        await context.SaveChangesAsync();
                        return true;

                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        // [HttpGet("GetBasket")]
        // public List<Products> GetProducts()
    }
}
