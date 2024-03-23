using System.Text.Json.Serialization;
using dotmeer.AliceApi.Models.Converters;

namespace dotmeer.AliceApi.Models.Capabilities;


[JsonConverter(typeof(OutOnlyConverter<CapabilityParameter>))]
public abstract class CapabilityParameter
{
    
}