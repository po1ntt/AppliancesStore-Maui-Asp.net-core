using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private AppliancesStoreContext appliancesStoreContext { get; set; }
        public UsersController()
        {
           appliancesStoreContext = new AppliancesStoreContext();
        }
        [HttpGet("AuthorizeUser")]
        public IActionResult UserAsync(string login, string password)
        {
           var user = appliancesStoreContext.Users.FirstOrDefault(p => p.Login == login && p.Password == password);
            if (user != null)
                return Ok(user);
            else
                return BadRequest();
        }
        [HttpPost("RegisterUser")]
        public IActionResult AddNewUser(User user)
        {


            if (string.IsNullOrWhiteSpace(user.Login))
                return BadRequest();
            var userToCheck = appliancesStoreContext.Users.FirstOrDefault(p => p.Login == user.Login);
            if (userToCheck != null)
                return BadRequest();
            if (string.IsNullOrWhiteSpace(user.Password))
                return BadRequest();
            if (!string.IsNullOrWhiteSpace(user.Patronymic))
                user.Patronymic = "-";
            if (!string.IsNullOrWhiteSpace(user.FirstName))
                user.FirstName = "-";
            if (!string.IsNullOrWhiteSpace(user.SecondName))
                user.SecondName = "-";
            if (!string.IsNullOrWhiteSpace(user.Gender))
                user.Gender = "-";
            appliancesStoreContext.Users.Add(new User() 
            { 
                Login = user.Login,
                Password = user.Password,
                FirstName = user.FirstName, SecondName = user.SecondName,
                Gender = user.Gender,
                Patronymic = user.Patronymic,

            });
            appliancesStoreContext.SaveChanges();
            return Ok(user);
        }
        [HttpGet("GetFavoritesUser")]
        public async Task<List<Product>> GetFavoritesUser(int userid)
        {
           var favorites = await appliancesStoreContext.Favorites.Include(p => p.Product.ProductCategory).Include(p=> p.Product.ProductBrand).Where(p => p.UserId == userid).ToListAsync();
           List<Product> result = new List<Product>();
           foreach(var item in favorites)
            {
                if(item.Product != null)
                {
                    result.Add(item.Product);
                }
            }
            return result;
        }
        [HttpGet("GetBasketUser")]
        public async Task<List<Product>> GetBasketUser(int userid)
        {
            var basket = await appliancesStoreContext.Baskets.Include(p => p.Product.ProductCategory).Include(p => p.Product.ProductBrand).ToListAsync();
            List<Product> result = new List<Product>();
            foreach (var item in basket)
            {
                if (item.Product != null)
                {
                    result.Add(item.Product);
                }
            }
            return result;
        }

    }
}
