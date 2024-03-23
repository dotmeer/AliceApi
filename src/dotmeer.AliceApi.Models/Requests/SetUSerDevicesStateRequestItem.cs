using System.Collections.Generic;
using System.Text.Json.Serialization;
using dotmeer.AliceApi.Models.Capabilities;

namespace dotmeer.AliceApi.Models.Requests;

public sealed class SetUSerDevicesStateRequestItem
{
    public string Id { get; init; } = default!;

    [JsonPropertyName("custom_data")]
    public IDictionary<string, object>? CustomData { get; init; }

    public IList<Capability> Capabilities { get; init; } = new List<Capability>(0);
}