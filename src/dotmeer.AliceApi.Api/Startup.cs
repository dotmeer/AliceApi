using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using dotmeer.AliceApi.Api.Authorization;
using dotmeer.AliceApi.Api.Middlewares;
using dotmeer.AliceApi.Application;
using dotmeer.AliceApi.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace dotmeer.AliceApi.Api;

// TODO: воркер для самовызова контейнера - чтобы не гас в яндексе
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
                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "Bearer",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
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
            .AddAuthentication()
            .AddScheme<TokenAuthenticationOptions, TokenAuthenticationHandler>(AuthConstants.SchemeName, _ => { });
        
        services
            .AddAuthorization(options =>
            {
                options.AddPolicy(AuthConstants.SchemeName, policy =>
                    policy.RequireClaim(AuthConstants.UserIdClaim));
            });

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

        app.UseRouting()
            .UseAuthentication()
            .UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}