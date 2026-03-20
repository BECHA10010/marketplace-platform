using Common.Logging.Extensions;

namespace Checkout.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddValidatorsFromAssembly(assembly);
        services.AddFluentValidationAutoValidation();
        
        services.AddExceptionHandler<CustomExceptionHandler>();
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
        
        services.AddCarter();
        services.AddCommonLogging(configuration);
        return services;
    }
}