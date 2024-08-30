using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet("timestamp")]
        public IActionResult GetTimestamp()
        {
            var utcTime = DateTime.UtcNow;
            var message = $"The current UTC time is {utcTime:yyyy-MM-ddTHH:mm:ssZ}";
            return Ok(message);
        }
    }
}
