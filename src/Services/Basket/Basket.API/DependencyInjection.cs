using Basket.API.Infrastructure;
using Basket.API.Infrastructure.Repositories;
using Carter;
using Microsoft.EntityFrameworkCore;

namespace Basket.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCarter();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        
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
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.MapCarter();
        
        return app;
    }
}