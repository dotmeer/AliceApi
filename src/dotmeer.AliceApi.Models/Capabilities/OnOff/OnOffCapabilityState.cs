using dotmeer.AliceApi.Models.Constants;

namespace dotmeer.AliceApi.Models.Capabilities.OnOff;

public sealed class OnOffCapabilityState : CapabilityState<bool>
{
    public OnOffCapabilityState() : base(CapabilityStateInstances.On)
    {
    }
}