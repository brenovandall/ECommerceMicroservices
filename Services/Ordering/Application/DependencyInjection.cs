using BuildingBlocks.Messaging.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection InjectApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
        });

        services.AddFeatureManagement();

        services.AddMessageBrokers(configuration, Assembly.GetExecutingAssembly());

        return services;
    }
}
