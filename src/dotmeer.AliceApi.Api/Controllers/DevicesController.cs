using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dotmeer.AliceApi.Api.Authorization;
using dotmeer.AliceApi.Application;
using dotmeer.AliceApi.Models.Requests;
using dotmeer.AliceApi.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotmeer.AliceApi.Api.Controllers;

[ApiController]
[Route("aliceapi/v1.0")]
[Authorize]
public sealed class DevicesController : ControllerBase
{
    private readonly IDevicesRepository _devicesRepository;

    public DevicesController(
        IDevicesRepository devicesRepository)
    {
        _devicesRepository = devicesRepository;
    }

    [HttpGet("user/devices")]
    public async Task<IActionResult> GetUserDevices(
        [FromHeader(Name = "X-Request-Id")] string? requestId,
        CancellationToken cancellationToken)
    {
        var response = new AliceResponseWithPayload
        {
            RequestId = requestId!,
            Payload = new Payload
            {
                UserId = User.FindFirst(AuthConstants.UserIdClaim)!.Value,
                Devices = _devicesRepository.GetDevices()
            }
        };

        return Ok(response);
    }

    [HttpPost("user/devices/query")]
    public async Task<IActionResult> GetUserDevicesState(
        [FromHeader(Name = "X-Request-Id")] string? requestId,
        [FromBody] GetUserDevicesStateRequest request,
        CancellationToken cancellationToken)
    {
        var response = new AliceResponseWithPayload
        {
            RequestId = requestId!,
            Payload = new Payload
            {
                UserId = User.FindFirst(AuthConstants.UserIdClaim)!.Value,
                Devices = _devicesRepository.GetDevices(request.Devices.Select(_ => _.Id).ToArray())
            }
        };

        return Ok(response);
    }

    [HttpPost("user/devices/action")]
    public async Task<IActionResult> SetUSerDevicesState(
        [FromHeader(Name = "X-Request-Id")] string? requestId,
        [FromBody] SetUSerDevicesStateRequest request,
        CancellationToken cancellationToken)
    {
        var response = new AliceResponseWithPayload
        {
            RequestId = requestId!,
            Payload = new Payload
            {
                UserId = User.FindFirst(AuthConstants.UserIdClaim)!.Value,
                Devices = _devicesRepository.UpdateDeviceState(request.Payload.Devices.ToList())
            }
        };

        return Ok(response);
    }
}