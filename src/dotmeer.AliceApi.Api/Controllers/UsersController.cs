using dotmeer.AliceApi.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotmeer.AliceApi.Api.Controllers;

[ApiController]
[Route("aliceapi/v1.0")]
[Authorize]
public sealed class UsersController : ControllerBase
{
    [HttpPost("user/unlink")]
    public IActionResult UnlinkUser(
        [FromHeader(Name = "X-Request-Id")] string? requestId)
    {
        return Ok(
            new AliceResponse
            {
                RequestId = requestId!
            });
    }
}