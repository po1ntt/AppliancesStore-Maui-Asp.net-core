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
            Byte[] b = System.IO.File.ReadAllBytes($"Images\\{name}");   // You can use your own method over here.         
            return File(b, "image/jpeg");
        }
    }
}
