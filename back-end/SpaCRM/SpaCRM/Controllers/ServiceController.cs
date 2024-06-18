using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaCRM.Commands.Service.GetList;

namespace SpaCRM.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class ServiceController(ISender sender) : ControllerBase
{
    [HttpGet("GetServices", Name = "GetServices")]
    [ProducesResponseType(typeof(GetServicesResponse), 200)]
    [AllowAnonymous]
    public async Task<IActionResult> GetServices() =>
        Ok(await sender.Send(new GetServicesQuery()));
}