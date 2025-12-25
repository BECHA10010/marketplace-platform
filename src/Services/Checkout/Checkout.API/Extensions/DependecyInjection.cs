using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace Checkout.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        TypeAdapterConfig.GlobalSettings.Scan(assembly);
        
        services.AddValidatorsFromAssembly(assembly);

        services.AddFluentValidationAutoValidation();
        
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, ServiceMapper>();
        
        services.AddExceptionHandler<CustomExceptionHandler>();
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
        
        services.AddCarter();
        
        return services;
    }
}