namespace dotmeer.AliceApi.Models.Parameters;

public sealed class EventPropertyState : PropertyState
{
    public EventPropertyState(string instance) : base(instance)
    {
    }

    public string Value { get; private set; } = default!;

    public override void UpdateValue(object value)
    {
        Value = value.ToString()!;
    }
}