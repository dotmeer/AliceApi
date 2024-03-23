using System.Text.Json.Serialization;
using dotmeer.AliceApi.Models.Converters;

namespace dotmeer.AliceApi.Models.Parameters;

[JsonConverter(typeof(OutOnlyConverter<PropertyParameter>))]
public abstract class PropertyParameter
{
    public string Instance { get; }

    protected PropertyParameter(string instance)
    {
        Instance = instance;
    }
}