namespace Promotion.Grpc.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var mySqlConnection = configuration.GetConnectionString("MySqlConnection");

        services.AddScoped<IDbConnection>(_ => new MySqlConnection(mySqlConnection));
        
        services.AddGrpcReflection();
        services.AddGrpc();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        services.AddScoped<IPromoRepository, PromoRepository>();
        
        MappingConfig.Configure();
        
        return services;
    }
    
    public static async Task<WebApplication> UseApiServices(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var connection = scope.ServiceProvider.GetRequiredService<IDbConnection>();
        
        await connection.SeedAsync();
        app.MapGrpcReflectionService();

        app.MapGrpcService<PromoGrpcService>();
        
        return app;
    }
}