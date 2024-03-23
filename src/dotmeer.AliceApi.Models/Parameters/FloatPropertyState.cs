using System;

namespace dotmeer.AliceApi.Models.Parameters;

public sealed class FloatPropertyState : PropertyState
{
    public FloatPropertyState(string instance) : base(instance)
    {
    }

    public double Value { get; private set; }

    public override void UpdateValue(object value)
    {
        Value = Convert.ToDouble(value);
    }
}