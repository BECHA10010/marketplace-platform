namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(config =>
        {
            var basePath = AppContext.BaseDirectory;
            config.IncludeXmlComments(Path.Combine(basePath, "Catalog.Domain.xml"));
        });
        
        var assembly = typeof(ApplicationErrors).Assembly;
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
        });
        
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapControllers();
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }
}