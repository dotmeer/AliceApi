using System.Text.Json.Serialization;

namespace dotmeer.AliceApi.Models.Capabilities.OnOff;

public sealed class OnOffCapabilityParameter : CapabilityParameter
{
    [JsonPropertyName("split")]
    public bool? Split { get; }

    public OnOffCapabilityParameter(bool? split)
    {
        Split = split;
    }
}