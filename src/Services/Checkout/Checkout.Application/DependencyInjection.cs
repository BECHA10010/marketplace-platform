namespace Checkout.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
        });
        
        return services;
    }
}