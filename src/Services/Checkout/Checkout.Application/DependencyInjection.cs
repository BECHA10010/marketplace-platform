using Common.Kernel.Behaviors;
using FluentValidation;

namespace Checkout.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddValidatorsFromAssembly(assembly);
        
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        TypeAdapterConfig.GlobalSettings.Scan(assembly);

        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, ServiceMapper>();
            
        return services;
    }
}