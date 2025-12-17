namespace Basket.API.Infrastructure.Persistence.Extensions;

public static class DatabaseExtensions
{
    public static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        
        var dbContext = scope.ServiceProvider.GetRequiredService<BasketDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}