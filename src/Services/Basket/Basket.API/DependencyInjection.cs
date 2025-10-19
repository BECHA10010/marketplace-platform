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
        var pgConnectionString = configuration.GetConnectionString("PgConnection")!;
        var redisConnectionString = configuration.GetConnectionString("RedisConnection")!;
        
        services.AddMarten(options =>
        {
            options.Connection(pgConnectionString);
            options.Schema.For<ShoppingCart>().Identity(x => x.AccountName);
        }).UseLightweightSessions();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
            options.InstanceName = "ShoppingCart";
        });
        
        services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        services.Decorate<IShoppingCartRepository, RedisCachedShoppingCartRepository>();
        
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