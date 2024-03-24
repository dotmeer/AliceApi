using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Templates;

namespace dotmeer.AliceApi.Infrastructure.Logging;

public static class Setup
{
    public static ILoggingBuilder AddYandexFormatted(this ILoggingBuilder builder)
    {
        var loggerConfiguration = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
            .WriteTo.Console(new ExpressionTemplate(
                "{ {" +
                "timestamp: UtcDateTime(@t), " +
                "message: @m, " +
                "level: if @l = 'Information' then 'INFO' else " +
                "if @l = 'Warning' then 'WARN' else " +
                "if @l = 'Error' then 'ERROR' else " +
                "if @l = 'Fatal' then 'FATAL' else @l, " +
                "exception: @x, " +
                "properties: @p" +
                "} }\n"));
        
        builder.AddSerilog(
            loggerConfiguration.CreateLogger());

        return builder;
    }
}