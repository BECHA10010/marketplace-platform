using Common.Logging.Middlewares;

namespace Checkout.API.Extensions;

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

        var dbContext = scope.ServiceProvider.GetRequiredService<CheckoutDbContext>();
        
        await dbContext.Database.MigrateAsync();
        await dbContext.SeedAsync();
    }
    
    private static void UseApiServices(this WebApplication app)
    {
        app.UseMiddleware<RequestLoggingMiddleware>();
        
        app.UseExceptionHandler(options => { });
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.MapCarter();
    }
}