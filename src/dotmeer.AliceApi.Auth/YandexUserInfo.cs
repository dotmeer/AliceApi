using System.Text.Json.Serialization;

namespace dotmeer.AliceApi.Auth;

internal sealed class YandexUserInfo
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("login")]
    public string Login { get; init; } = default!;

    [JsonPropertyName("default_email")]
    public string DefaultEmail { get; init; } = default!;
}