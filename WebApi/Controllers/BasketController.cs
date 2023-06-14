using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        public AppliancesStoreContext appliancesStoreContext { get; set; }
        public BasketController()
        {
            appliancesStoreContext = new AppliancesStoreContext();
        }
        [HttpGet("GetBasket")]
        public async Task<List<Basket>> GetBasket(int userid)
        {
            var collection = new List<Basket>();
            collection =  await appliancesStoreContext.Baskets.Where(p=> p.UserId == userid).ToListAsync();
            return collection;
        }
        [HttpPost("AddProductToBasket")]
        public IActionResult AddProductToBasket(Basket basket)
        {
            if (basket == null)
                return BadRequest();
            appliancesStoreContext.Baskets.Add(new Basket
            { 
                UserId = basket.UserId,
                ProductId = basket.ProductId
            });
            appliancesStoreContext.SaveChanges();
            return Ok();
        }
        [HttpPut("UpdateProductPlus")]
        public async Task<IActionResult> UpdateProductPlus(Basket basket)
        {
            if (basket == null)
                return BadRequest();
            var basketToUpdate = await appliancesStoreContext.Baskets.FirstOrDefaultAsync(p=> p.IdBasket == basket.IdBasket);
            if(basketToUpdate != null)
            {
                basketToUpdate.CountProduct = basketToUpdate.CountProduct++;
                appliancesStoreContext.SaveChanges();
                return Ok();
            }
            return BadRequest();    
        }
        [HttpPut("UpdateProductMinus")]
        public async Task<IActionResult> UpdateProductMinus(Basket basket)
        {
            if (basket == null)
                return BadRequest();
            var basketToUpdate = await appliancesStoreContext.Baskets.FirstOrDefaultAsync(p => p.IdBasket == basket.IdBasket);
            if (basketToUpdate != null)
            {
                basketToUpdate.CountProduct = basketToUpdate.CountProduct--;
                appliancesStoreContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("DeleteProductFromBasket")]
        public IActionResult DeleteProductFromBasket(int id_basket)
        {
            
            var baskettoremove = appliancesStoreContext.Baskets.FirstOrDefault(p => p.IdBasket == id_basket);
            if (baskettoremove == null)
                return BadRequest();
            appliancesStoreContext.Baskets.Remove(baskettoremove);
            appliancesStoreContext.SaveChanges();
            return Ok();
        }
    }
}
