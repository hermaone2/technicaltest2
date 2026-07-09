using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechnicalTestAPI.DTOs.Request;
using TechnicalTestAPI.DTOs.Response;

namespace TechnicalTestAPI.Controllers;

[Route("api")]
[ApiController]
public class MockController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public MockController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("soal1")]
    public async Task<IActionResult> GetListProduct([FromBody] SubmissionRequestDto data)
    {
        if (data == null)
            return BadRequest("Invalid payload");

        var response = new SubmissionResponseDto
        {
            ErrorSchema = new ErrorSchemaDto
            {
                ErrorCode = "SEEDS-00-000",
                ErrorMessage = new ErrorMessageDto
                {
                    English = "Sukses",
                    Indonesian = "Success"
                }
            },
            OutputSchema = new OutputSchemaDto
            {
                NorefSubmission = data.NorefSubmission,
                ProductData = data.ProductData?.Select(p => new ProductDataResponseDto
                {
                    ProductCd = p.ProductCd,
                    NorefProduct = p.NorefProduct,
                    StatusCdProduct = "01-002"
                }).ToList() ?? new List<ProductDataResponseDto>()
            }
        };
        
        await Task.CompletedTask;

        return Ok(response);
    }

    [HttpGet("endpoint")]
    public async Task<IActionResult> GetMock2()
    {
        var filePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ContohJson", "RespondEndPoint2.json");
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("File JSON tidak ditemukan.");
        }

        var json = await System.IO.File.ReadAllTextAsync(filePath);
        return Content(json, "application/json");
    }
}
