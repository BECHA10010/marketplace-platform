namespace Checkout.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var pgConnection = configuration.GetConnectionString("PgConnection");
    
        services.AddDbContext<CheckoutDbContext>(options =>
        {
            options.UseNpgsql(pgConnection);
        });

        services.AddScoped<IOrderRepository, OrderRepository>();
        
        return services;
    }
}