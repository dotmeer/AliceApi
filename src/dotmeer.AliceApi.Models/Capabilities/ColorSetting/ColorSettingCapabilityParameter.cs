using System.Text.Json.Serialization;

namespace dotmeer.AliceApi.Models.Capabilities.ColorSetting;

public sealed class ColorSettingCapabilityParameter : CapabilityParameter
{
    public ColorSettingCapabilityParameter(
        string colorModel, 
        TemperatureColorSettingCapabilityParameter temperatureK, 
        ScenesColorSettingCapabilityParameter colorScene)
    {
        ColorModel = colorModel;
        TemperatureK = temperatureK;
        ColorScene = colorScene;
    }

    [JsonPropertyName("color_model")]
    public string ColorModel { get; }

    [JsonPropertyName("temperature_k")]
    public TemperatureColorSettingCapabilityParameter TemperatureK { get; }

    [JsonPropertyName("color_scene")]
    public ScenesColorSettingCapabilityParameter ColorScene { get; }
}