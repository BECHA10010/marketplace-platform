using Common.Logging.Extensions;

namespace Catalog.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(Program).Assembly;
        
        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddControllers();
        services.AddValidatorsFromAssembly(assembly);
        services.AddFluentValidationAutoValidation();
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
        
        services.AddCommonLogging(configuration);
        
        return services;
    }
}