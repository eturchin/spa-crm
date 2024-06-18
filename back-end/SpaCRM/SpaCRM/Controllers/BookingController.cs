using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaCRM.Commands.Booking.Create;
using SpaCRM.Commands.Booking.GetMy;

namespace SpaCRM.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class BookingController(ISender sender) : ControllerBase
{
    [HttpPost("CreateBooking", Name = "CreateBooking")]
    [ProducesResponseType(typeof(CreateBookingResponse), 201)]
    public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
    {
        var idClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (idClaim == null)
        {
            return BadRequest("User ID not found in the token.");
        }

        if (!Guid.TryParse(idClaim.Value, out var userId))
        {
            return BadRequest("Invalid user ID in the token.");
        }

        command.UserId = userId;
        
        var response = await sender.Send(command);
        
        return Ok(response);
    }
    
    [HttpGet("GetMyAppointments", Name = "GetMyAppointments")]
    [ProducesResponseType(typeof(GetMyAppointmentsHandler), 200)]
    public async Task<IActionResult> GetMyAppointments()
    {
        var idClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (idClaim == null)
        {
            return BadRequest("User ID not found in the token.");
        }

        if (!Guid.TryParse(idClaim.Value, out var userId))
        {
            return BadRequest("Invalid user ID in the token.");
        }

        var query = new GetMyAppointmentsQuery
        {
            UserId = userId
        };
        
        var response = await sender.Send(query);
        
        return Ok(response);
    }
}