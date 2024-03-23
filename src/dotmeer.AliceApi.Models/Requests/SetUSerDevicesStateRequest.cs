namespace dotmeer.AliceApi.Models.Requests;

public sealed class SetUSerDevicesStateRequest
{
    public SetUSerDevicesStateRequestPayload Payload { get; init; } = new();
}