using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet("timestamp")]
        public IActionResult GetTimestamp()
        {
            var timestamp = DateTime.UtcNow;
            return Ok(new { Timestamp = timestamp });
        }
    }
}
