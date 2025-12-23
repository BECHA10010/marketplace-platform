using Catalog.Infrastructure.Seeding;

namespace Catalog.API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> ConfigureApiAsync(this WebApplication app)
    {
        await app.MigrateAndSeedDatabaseAsync();
        app.UseApiServices();
        
        return app;
    }
    
    private static async Task MigrateAndSeedDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
        
        await dbContext.Database.MigrateAsync();
        await dbContext.SeedAsync();
    }
    
    private static void UseApiServices(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
            options.SwaggerEndpoint("/swagger/v2/swagger.json", "Catalog API v2");
        });
        
        app.MapControllers();
    }
}