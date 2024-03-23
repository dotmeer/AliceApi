using System.Collections.Generic;

namespace dotmeer.AliceApi.Models.Capabilities.ColorSetting;

public sealed class ScenesColorSettingCapabilityParameter
{
    public ScenesColorSettingCapabilityParameter(IReadOnlyList<SceneColorSettingCapabilityParameter> scenes)
    {
        Scenes = scenes;
    }

    public IReadOnlyList<SceneColorSettingCapabilityParameter> Scenes { get; }
}