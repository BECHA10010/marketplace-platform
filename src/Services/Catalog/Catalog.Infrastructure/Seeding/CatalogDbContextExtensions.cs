namespace Catalog.Infrastructure.Seeding;

public static class CatalogDbContextExtensions
{
    public static async Task SeedAsync(this CatalogDbContext catalogDbContext)
    {
        if (!await catalogDbContext.Categories.AnyAsync())
            catalogDbContext.Categories.AddRange(InitialData.Categories);
        
        if (!await catalogDbContext.Brands.AnyAsync())
            catalogDbContext.Brands.AddRange(InitialData.Brands);
        
        if (!await catalogDbContext.CatalogItems.AnyAsync())
            catalogDbContext.CatalogItems.AddRange(InitialData.CatalogItems);

        await catalogDbContext.SaveChangesAsync();
    }
}

/*
 *public interface ICatalogDataSeeder
{
    Task SeedAsync(CancellationToken ct = default);
}
 *
 * internal sealed class CatalogDataSeeder : ICatalogDataSeeder
{
    private readonly CatalogDbContext _context;

    public CatalogDataSeeder(CatalogDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync(CancellationToken ct = default)
    {
        if (!await _context.Categories.AnyAsync(ct))
            _context.Categories.AddRange(InitialData.Categories);

        if (!await _context.Brands.AnyAsync(ct))
            _context.Brands.AddRange(InitialData.Brands);

        if (!await _context.CatalogItems.AnyAsync(ct))
            _context.CatalogItems.AddRange(InitialData.CatalogItems);

        await _context.SaveChangesAsync(ct);
    }
}
 */