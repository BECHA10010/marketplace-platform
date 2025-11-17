namespace Checkout.Infrastructure.Data.Extensions;

public static class WebApplicationExtensions
{
    public static async Task MigrateAndSeedDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
        
        await dbContext.Database.MigrateAsync();
        await OrderDbContextSeed.SeedAsync(dbContext);
    }
}