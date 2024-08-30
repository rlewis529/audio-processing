using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly ILogger<ApiController> _logger;
    private readonly string[] _permittedExtensions = { ".wav", ".mp3" };

    public ApiController(ILogger<ApiController> logger)
    {
        _logger = logger;
    }

    // 1. Test API Endpoint
    [HttpGet("test")]
    public IActionResult TestApi()
    {
        _logger.LogInformation("Test API endpoint hit at {Time}", DateTime.UtcNow);
        return Ok("API is available and working!");
    }

    // [HttpPost("upload")]
    // public IActionResult UploadAudio([FromForm] IFormFile file)
    // {
    //     if (file == null || file.Length == 0)
    //     {
    //         return BadRequest("No file was uploaded.");
    //     }

    //     var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
    //     if (string.IsNullOrEmpty(ext) || !_permittedExtensions.Contains(ext))
    //     {
    //         return BadRequest("Invalid file format. Please upload a .wav or .mp3 file.");
    //     }

    //     // Logging and processing the file (if necessary)
    //     _logger.LogInformation("File {FileName} uploaded successfully at {Time}", file.FileName, DateTime.UtcNow);

    //     return Ok(new { message = "File uploaded successfully!", fileName = file.FileName });
    // }
}
