using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string name)
        {
            var b = System.IO.File.OpenRead($"Images\\{name}");           
            return File(b, "image/png");
        }
    }
}
