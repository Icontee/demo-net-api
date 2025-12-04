using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() =>
            Ok(new { message = "Hello from Azure Pipeline Demo!" });
    }
}
