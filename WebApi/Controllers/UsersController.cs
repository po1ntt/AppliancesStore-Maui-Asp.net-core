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
       
    }
}
