using Microsoft.AspNetCore.Mvc;

namespace SmartTravel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Test successful");
        }
    }
}
