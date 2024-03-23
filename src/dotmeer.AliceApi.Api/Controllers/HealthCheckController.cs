using System.Threading;
using System.Threading.Tasks;
using dotmeer.AliceApi.Auth;
using Microsoft.AspNetCore.Mvc;

namespace dotmeer.AliceApi.Api.Controllers;

[ApiController]
[Route("aliceapi/v1.0")]
public sealed class HealthCheckController : ControllerBase
{
    private readonly IUserService _userService;

    public HealthCheckController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpHead]
    public async Task<IActionResult> HealthCheck(
        [FromHeader(Name = "Authorization")] string? token,
        CancellationToken cancellationToken)
    {
        await _userService.GetUserIdAsync(token, cancellationToken);

        return Ok();
    }
}