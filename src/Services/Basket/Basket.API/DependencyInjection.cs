using Common.Kernel.Behaviors;
using Common.Kernel.Exceptions;
using Common.Kernel.Exceptions.Handler;
using FluentValidation;

namespace Basket.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCarter();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PgConnection")
            ?? throw new InvalidOperationException("Connection string 'PgConnection' not found");

        services.AddDbContext<BasketDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

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