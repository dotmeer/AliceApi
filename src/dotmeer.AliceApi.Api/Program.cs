using System;
using System.Net;
using System.Threading.Tasks;
using dotmeer.AliceApi.Infrastructure.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dotmeer.AliceApi.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                configurationBuilder.Sources.Clear();

                configurationBuilder
                    .AddJsonFile("appsettings.json", false, false)
                    .AddEnvironmentVariables()
                    .Build();
            })
            .ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddYandexFormatted();
            })
            .UseDefaultServiceProvider(serviceProviderOptions =>
            {
                serviceProviderOptions.ValidateScopes = true;
                serviceProviderOptions.ValidateOnBuild = true;
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, int.Parse(Environment.GetEnvironmentVariable("PORT")!));
                    })
                    .UseStartup<Startup>();
            })
            .Build()
            .RunAsync();
    }
}