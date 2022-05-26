using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return $"Time now is {DateTime.Now}";
        }
    }
}
