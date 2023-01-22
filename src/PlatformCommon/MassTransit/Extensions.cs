using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformCommon.Settings;

namespace PlatformCommon.MassTransit;

public static class Extensions
{
    public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services, Action<IRetryConfigurator>? configureRetries = null)
    {
        services.AddMassTransit(configure =>
        {
            configure.UsingRabbitMq((context, configurator) =>
            {
                var configuration = context.GetService<IConfiguration>();
                var rabbitMqSettings = configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
                configurator.Host(rabbitMqSettings.Host);
                configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(rabbitMqSettings.SvcMsgsPrefix, false));

                if (configureRetries == null)
                {
                    configureRetries = (config) => config.Interval(3, TimeSpan.FromSeconds(5));
                }
                configurator.UseMessageRetry(configureRetries);
            });
            configure.AddConsumers(Assembly.GetEntryAssembly());
        });

        return services;
    }
}