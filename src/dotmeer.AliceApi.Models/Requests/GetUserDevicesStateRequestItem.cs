using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace dotmeer.AliceApi.Models.Requests;

public sealed class GetUserDevicesStateRequestItem
{
    public string Id { get; init; } = default!;

    [JsonPropertyName("custom_data")]
    public IDictionary<string, object>? CustomData { get; init; }
}