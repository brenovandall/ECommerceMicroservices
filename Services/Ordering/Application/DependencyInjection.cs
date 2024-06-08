using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}
