using System.Text.Json.Serialization;
using dotmeer.AliceApi.Models.Converters;

namespace dotmeer.AliceApi.Models.Capabilities;

[JsonConverter(typeof(CapabilityStateConverter))]
public abstract class CapabilityState
{
    public string Instance { get; init; } = default!;

    [JsonPropertyName("action_result")]
    public CapabilityStateActionResult? ActionResult { get; set; }

    public abstract void SetValue(object? value);
    public abstract object? GetValue();

    public CapabilityState GetCopy()
    {
        return (CapabilityState)MemberwiseClone();
    }
}