using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotmeer.AliceApi.Auth;

public static class Setup
{
    public static IServiceCollection SetupYandexAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("UserService").Get<UserServiceSettings>()
            ?? throw new ArgumentNullException(nameof(UserServiceSettings));

        services
            .AddSingleton(settings)
            .AddHttpClient()
            .AddSingleton<IUserService, UserService>();

        return services;
    }
}