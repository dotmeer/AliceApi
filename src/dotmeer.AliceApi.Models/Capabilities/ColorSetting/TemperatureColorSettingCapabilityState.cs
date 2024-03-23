using dotmeer.AliceApi.Models.Constants;

namespace dotmeer.AliceApi.Models.Capabilities.ColorSetting;

public sealed class TemperatureColorSettingCapabilityState : CapabilityState<int>
{
    public TemperatureColorSettingCapabilityState() : base(CapabilityStateInstances.TemperatureK)
    {
    }
}