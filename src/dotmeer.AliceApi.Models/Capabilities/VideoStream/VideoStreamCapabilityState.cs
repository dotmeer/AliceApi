using dotmeer.AliceApi.Models.Constants;

namespace dotmeer.AliceApi.Models.Capabilities.VideoStream;

public sealed class VideoStreamCapabilityState : CapabilityState<VideoStreamValue>
{
    public VideoStreamCapabilityState() : base(CapabilityStateInstances.GetStream)
    {
    }
}