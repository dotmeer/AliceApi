using dotmeer.AliceApi.Models.Constants;

namespace dotmeer.AliceApi.Models.Capabilities.ColorSetting;

public sealed class RgbColorSettingCapabilityState : CapabilityState<int>
{
    public RgbColorSettingCapabilityState() : base(CapabilityStateInstances.Rgb)
    {
    }
}