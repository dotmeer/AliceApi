using System.Text.Json;
using System.Text.Json.Serialization;
using dotmeer.AliceApi.Api.Middlewares;
using dotmeer.AliceApi.Application;
using dotmeer.AliceApi.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace dotmeer.AliceApi.Api;

internal sealed class Startup
{
    private readonly IConfiguration _configuration;

    private const string Prefix = "aliceapi";

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(_ =>
            {
                _.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                _.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                _.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

        services
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Default", Version = "v1" });
                options.CustomSchemaIds(_ => _.FullName);
                options.UseAllOfToExtendReferenceSchemas();
                options.SupportNonNullableReferenceTypes();
            });

        services
            .AddRouting(options =>
            {
                options.AppendTrailingSlash = true;
            });

        services
            .SetupYandexAuth(_configuration)
            .SetupApplication();

        services
            .AddScoped<LoggingMiddleware>()
            .AddScoped<ExceptionsMiddleware>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger(swaggerOptions =>
        {
            swaggerOptions.RouteTemplate = $"/{Prefix}/swagger/{{documentName}}/swagger.json";
        });

        app.UseSwaggerUI(swaggerUiOptions =>
        {
            swaggerUiOptions.RoutePrefix = $"{Prefix}/swagger";
            swaggerUiOptions.SwaggerEndpoint($"/{Prefix}/swagger/v1/swagger.json", "API");
            swaggerUiOptions.DisplayRequestDuration();
        });

        app.UseMiddleware<LoggingMiddleware>()
            .UseMiddleware<ExceptionsMiddleware>();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}