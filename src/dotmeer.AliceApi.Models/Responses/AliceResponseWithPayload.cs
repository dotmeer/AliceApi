namespace dotmeer.AliceApi.Models.Responses;

public sealed class AliceResponseWithPayload : AliceResponse
{
    public Payload Payload { get; init; } = default!;
}