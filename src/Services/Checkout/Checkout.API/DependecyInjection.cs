namespace Checkout.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCarter();
        
        return services;
    }
    
    public static async Task<WebApplication> UseApiServices(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        app.MapCarter();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        await app.Services.MigrateAndSeedDatabaseAsync();
        
        return app;
    }
}