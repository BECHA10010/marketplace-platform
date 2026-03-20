using Common.Logging.Middlewares;

namespace Basket.API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> ConfigureApiAsync(this WebApplication app)
    {
        await app.MigrateDatabaseAsync();
        app.UseApiServices();
        
        return app;
    }
    
    private static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        
        var dbContext = scope.ServiceProvider.GetRequiredService<BasketDbContext>();
        await dbContext.Database.MigrateAsync();
    }
    
    private static void UseApiServices(this WebApplication app)
    {
        app.UseMiddleware<RequestLoggingMiddleware>();
        
        app.UseExceptionHandler(options => { });
        
        app.MapCarter();
        
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}