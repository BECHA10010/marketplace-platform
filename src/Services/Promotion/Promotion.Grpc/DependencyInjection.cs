using Common.Metrics.Extensions;

namespace Promotion.Grpc;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var mySqlConnection = configuration.GetConnectionString("MySqlConnection");

        services.AddScoped<IDbConnection>(_ => new MySqlConnection(mySqlConnection));

        services.AddSingleton<RequestLoggingInterceptor>();
        
        services.AddGrpcReflection();
        services.AddGrpc(options =>
        {
            options.Interceptors.Add<RequestLoggingInterceptor>();
            options.EnableDetailedErrors = true;
        });

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        services.AddScoped<IPromoRepository, PromoRepository>();

        services.AddCommonLogging(configuration);
        
        PromoMappingConfig.Configure();
        
        return services;
    }
    
    public static async Task<WebApplication> UseApiServices(this WebApplication app)
    {
        app.UsePrometheusMetrics();
        
        using var scope = app.Services.CreateScope();
        var connection = scope.ServiceProvider.GetRequiredService<IDbConnection>();
        
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        await connection.SeedAsync(logger);
        
        app.MapGrpcReflectionService();

        app.MapGrpcService<PromoGrpcService>();
        
        return app;
    }
}