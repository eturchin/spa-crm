using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaCRM.Commands.Specialist.GetList;

namespace SpaCRM.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class SpecialistController(ISender sender) : ControllerBase
{
    [HttpGet("GetSpecialists", Name = "GetSpecialists")]
    [ProducesResponseType(typeof(GetSpecialistsResponse), 200)]
    [AllowAnonymous]
    public async Task<IActionResult> GetSpecialists([FromQuery] GetSpecialistsQuery query) =>
        Ok(await sender.Send(query));
}
