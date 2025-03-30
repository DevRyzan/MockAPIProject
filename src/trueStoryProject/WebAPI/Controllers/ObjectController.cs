using Application.Features.MockAPIModels.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObjectController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> CreateObject([FromBody] CreateObjectCommand createBrandCommand)
    {
        try
        {
            string result = await Mediator.Send(createBrandCommand);
            return Ok(result);
        }
        catch (ArgumentException ex)  
        {
            return BadRequest($"Bad Request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        } 
    }
}
