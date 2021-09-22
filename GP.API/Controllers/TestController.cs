using Microsoft.AspNetCore.Mvc;

namespace GP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello!");
        }
    }
}
