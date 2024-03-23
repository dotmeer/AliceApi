using dotmeer.AliceApi.Models.Constants;

namespace dotmeer.AliceApi.Models.Capabilities.ColorSetting;

public sealed class HsvColorSettingCapabilityState : CapabilityState<Hsv>
{
    public HsvColorSettingCapabilityState() : base(CapabilityStateInstances.Hsv)
    {
    }
}