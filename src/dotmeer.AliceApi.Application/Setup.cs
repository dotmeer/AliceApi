using Microsoft.Extensions.DependencyInjection;

namespace dotmeer.AliceApi.Application;

public static class Setup
{
    public static IServiceCollection SetupApplication(this IServiceCollection services)
    {
        services
            .AddSingleton<IDevicesRepository, DevicesRepository>();

        return services;
    }
}