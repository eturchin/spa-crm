using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaCRM.Commands.User.GetMe;
using SpaCRM.Commands.User.Login;
using SpaCRM.Commands.User.Register;

namespace SpaCRM.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class UserController(ISender sender) : ControllerBase
{
    [HttpGet("GetMe", Name = "GetMe")]
    [ProducesResponseType(typeof(GetMeResponse), 200)]
    [Authorize(Policy = "All")]
    public async Task<IActionResult> GetMe()
    {
        var idClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (idClaim == null)
        {
            return BadRequest("User ID not found in the token.");
        }

        if (!Guid.TryParse(idClaim.Value, out var id))
        {
            return BadRequest("Invalid user ID in the token.");
        }
        
        var query = new GetMeQuery(id);
        var response = await sender.Send(query);
        
        return Ok(response);
    }
    
    [HttpPost("Register", Name = "Register")]
    [ProducesResponseType(typeof(RegisterUserResponse), 201)]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command) =>
        Ok(await sender.Send(command));
    
    [HttpPost("Login", Name = "Login")]
    [ProducesResponseType(typeof(LoginUserResponse), 200)]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command) =>
        Ok(await sender.Send(command));
}