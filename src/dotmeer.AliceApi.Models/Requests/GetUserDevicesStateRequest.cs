using System.Collections.Generic;

namespace dotmeer.AliceApi.Models.Requests;

public sealed class GetUserDevicesStateRequest
{
    public IList<GetUserDevicesStateRequestItem> Devices { get; init; } = new List<GetUserDevicesStateRequestItem>(0);
}