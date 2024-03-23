using dotmeer.AliceApi.Auth;
using dotmeer.AliceApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace dotmeer.AliceApi.Api.Controllers;

[ApiController]
[Route("aliceapi/v1.0")]
public sealed class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("user/unlink")]
    public async Task<IActionResult> UnlinkUser(
        [FromHeader(Name = "Authorization")] string? token,
        [FromHeader(Name = "X-Request-Id")] string? requestId,
        CancellationToken cancellationToken)
    {
        await _userService.GetUserIdAsync(token, cancellationToken);

        return Ok(
            new AliceResponse
            {
                RequestId = requestId!
            });
    }
}