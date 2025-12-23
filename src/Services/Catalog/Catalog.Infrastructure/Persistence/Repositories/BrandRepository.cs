namespace Catalog.Infrastructure.Persistence.Repositories;

public class BrandRepository(CatalogDbContext context) : BaseRepository<Brand>(context), IBrandRepository
{
    public async Task<Brand?> GetByNameAsync(string name, CancellationToken ct)
    {
        return await Context.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name == name, ct);
    }
}