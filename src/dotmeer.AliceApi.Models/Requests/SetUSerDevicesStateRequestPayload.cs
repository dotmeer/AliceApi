using System.Collections.Generic;

namespace dotmeer.AliceApi.Models.Requests;

public sealed class SetUSerDevicesStateRequestPayload
{
    public IList<SetUSerDevicesStateRequestItem> Devices { get; init; } = new List<SetUSerDevicesStateRequestItem>(0);
}