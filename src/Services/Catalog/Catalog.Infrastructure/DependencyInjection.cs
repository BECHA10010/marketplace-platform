namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PgConnection")!;

        services.AddMarten(options =>
        {
            options.Connection(connectionString);
        }).UseLightweightSessions();//.InitializeWith<InitializeDatabaseAsync>();

        services.AddScoped<IBrandRepository, CatalogRepository>();
        services.AddScoped<ICatalogItemRepository, CatalogRepository>();
        services.AddScoped<ICategoryRepository, CatalogRepository>();
        
        return services;
    }
}