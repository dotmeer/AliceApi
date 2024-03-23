using System.Collections.Generic;

namespace dotmeer.AliceApi.Models.Capabilities.VideoStream;

public sealed class VideoStreamCapabilityParameter : CapabilityParameter
{
    public VideoStreamCapabilityParameter()
    {
        Protocols = new []{ "hls" };
    }

    public IReadOnlyList<string> Protocols { get; }
}