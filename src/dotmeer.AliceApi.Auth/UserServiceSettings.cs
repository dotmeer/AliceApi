using System;
using System.Collections.Generic;

namespace dotmeer.AliceApi.Auth;

internal sealed class UserServiceSettings
{
    public IReadOnlyCollection<string> AllowedUsers { get; init; } = Array.Empty<string>();
}