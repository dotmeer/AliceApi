﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using dotmeer.AliceApi.Models.Capabilities;
using dotmeer.AliceApi.Models.Parameters;

namespace dotmeer.AliceApi.Models;

public sealed class Device
{
    public string Id { get; init; } = default!;

    public string Name { get; init; } = default!;

    public string Description { get; init; } = default!;

    public string? Room { get; init; }

    public string Type { get; init; } = default!;

    [JsonPropertyName("custom_data")]
    public IDictionary<string, object>? CustomData { get; init; }

    public IList<Capability> Capabilities { get; init; } = new List<Capability>(0);

    public IList<Property> Properties { get; init; } = new List<Property>(0);

    public Device GetUpdatedDevice()
    {
        return new Device
        {
            Id = Id
        };
    }
}