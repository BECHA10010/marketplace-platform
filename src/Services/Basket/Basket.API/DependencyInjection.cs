namespace Basket.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(Program).Assembly;
        
        services.AddExceptionHandler<CustomExceptionHandler>();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCarter();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);
        
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PgConnection")!;
        
        services.AddMarten(options =>
        {
            options.Connection(connectionString);
            options.Schema.For<ShoppingCart>().Identity(x => x.AccountName);
        }).UseLightweightSessions();

        services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        
        return services;
    }
    
    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        
        app.MapCarter();
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }
}