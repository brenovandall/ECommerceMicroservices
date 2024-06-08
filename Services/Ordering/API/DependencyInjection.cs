namespace API;

public static class DependencyInjection
{
    public static IServiceCollection InjectApiServices(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}
