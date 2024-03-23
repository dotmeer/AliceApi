using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dotmeer.AliceApi.Application;
using dotmeer.AliceApi.Auth;
using dotmeer.AliceApi.Models.Requests;
using dotmeer.AliceApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace dotmeer.AliceApi.Api.Controllers;

[ApiController]
[Route("wbgateway/v1.0")]
public sealed class DevicesController : ControllerBase
{
    private readonly IDevicesRepository _devicesRepository;

    private readonly IUserService _userService;

    public DevicesController(
        IDevicesRepository devicesRepository,
        IUserService userService)
    {
        _devicesRepository = devicesRepository;
        _userService = userService;
    }

    // TODO: вынести в отдельный контроллер
    [HttpHead]
    public async Task<IActionResult> HealthCheck(
        [FromHeader(Name = "Authorization")] string? token,
        CancellationToken cancellationToken)
    {
        await _userService.GetUserIdAsync(token, cancellationToken);
        
        return Ok();
    }

    // TODO: вынести в отдельный контроллер
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

    [HttpGet("user/devices")]
    public async Task<IActionResult> GetUserDevices(
        [FromHeader(Name = "Authorization")] string? token,
        [FromHeader(Name = "X-Request-Id")] string? requestId,
        CancellationToken cancellationToken)
    {
        var userId = await _userService.GetUserIdAsync(token, cancellationToken);

        var response = new AliceResponseWithPayload
        {
            RequestId = requestId!,
            Payload = new Payload
            {
                UserId = userId,
                Devices = _devicesRepository.GetDevices()
            }
        };

        return Ok(response);
    }

    [HttpPost("user/devices/query")]
    public async Task<IActionResult> GetUserDevicesState(
        [FromHeader(Name = "Authorization")] string? token,
        [FromHeader(Name = "X-Request-Id")] string? requestId,
        [FromBody] GetUserDevicesStateRequest request,
        CancellationToken cancellationToken)
    {
        var userId = await _userService.GetUserIdAsync(token, cancellationToken);
        
        var response = new AliceResponseWithPayload
        {
            RequestId = requestId!,
            Payload = new Payload
            {
                UserId = userId,
                Devices = _devicesRepository.GetDevices(request.Devices.Select(_ => _.Id).ToArray())
            }
        };

        return Ok(response);
    }

    [HttpPost("user/devices/action")]
    public async Task<IActionResult> SetUSerDevicesState(
        [FromHeader(Name = "Authorization")] string? token,
        [FromHeader(Name = "X-Request-Id")] string? requestId,
        [FromBody] SetUSerDevicesStateRequest request,
        CancellationToken cancellationToken)
    {
        var userId = await _userService.GetUserIdAsync(token, cancellationToken);

        var response = new AliceResponseWithPayload
        {
            RequestId = requestId!,
            Payload = new Payload
            {
                UserId = userId,
                Devices = _devicesRepository.UpdateDeviceState(request.Payload.Devices.ToList())
            }
        };

        return Ok(response);
    }
}