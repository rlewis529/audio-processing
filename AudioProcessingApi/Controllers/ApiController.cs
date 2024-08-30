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

    // 2. File Upload API Endpoint
    [HttpPost("upload")]
    public IActionResult UploadAudio([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file was uploaded.");
        }

        // Check file extension
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (string.IsNullOrEmpty(ext) || !_permittedExtensions.Contains(ext))
        {
            return BadRequest("Invalid file format. Please upload a .wav or .mp3 file.");
        }

        // Process the file (if necessary)
        // For now, we are just returning a success message
        _logger.LogInformation("File {FileName} uploaded successfully at {Time}", file.FileName, DateTime.UtcNow);

        return Ok(new { message = "File uploaded successfully!", fileName = file.FileName });
    }
}
