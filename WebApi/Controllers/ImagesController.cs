using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpGet]
        public Byte[] Get(string name)
        {
            Byte[] b = System.IO.File.ReadAllBytes($"Images\\{name}");           
            return b;
        }
    }
}
