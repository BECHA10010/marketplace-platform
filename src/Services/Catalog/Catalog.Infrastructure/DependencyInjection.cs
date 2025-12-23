namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var pgConnection = configuration.GetConnectionString("PgConnection");
    
        services.AddDbContext<CatalogDbContext>(options =>
        {
            options.UseNpgsql(pgConnection);
        });

        /*services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICatalogItemRepository, CatalogRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();*/
        
        return services;
    }
}