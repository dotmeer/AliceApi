using System.Text.Json.Serialization;
using dotmeer.AliceApi.Models.Converters;

namespace dotmeer.AliceApi.Models.Parameters;

[JsonConverter(typeof(OutOnlyConverter<PropertyState>))]
public abstract class PropertyState
{
    public string Instance { get; }

    protected PropertyState(string instance)
    {
        Instance = instance;
    }

    public abstract void UpdateValue(object  value);
}