using Application.Features.MockAPIModels.Commands.Create;
using Application.Features.ObjectModels.Commands.Delete;
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
            var result = await Mediator.Send(createBrandCommand);
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
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveObject(string id)
    {
        try
        {
            var result = await Mediator.Send(new DeleteObjectCommand(id));

            if (result == null)
            {
                return NotFound($"Object with ID {id} not found.");
            }

            return Ok($"Object with ID {id} successfully removed.");
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
