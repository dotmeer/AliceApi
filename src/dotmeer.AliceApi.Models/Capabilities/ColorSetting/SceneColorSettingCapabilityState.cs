using dotmeer.AliceApi.Models.Constants;

namespace dotmeer.AliceApi.Models.Capabilities.ColorSetting;

public sealed class SceneColorSettingCapabilityState : CapabilityState<string>
{
    public SceneColorSettingCapabilityState() : base(CapabilityStateInstances.Scene)
    {
    }
}