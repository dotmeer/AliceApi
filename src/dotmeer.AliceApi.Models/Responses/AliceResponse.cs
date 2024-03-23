using System.Text.Json.Serialization;

namespace dotmeer.AliceApi.Models.Responses;

public class AliceResponse
{
    [JsonPropertyName("request_id")]
    public string RequestId { get; init; } = default!;
}