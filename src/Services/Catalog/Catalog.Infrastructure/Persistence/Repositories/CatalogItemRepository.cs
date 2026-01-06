namespace Catalog.Infrastructure.Persistence.Repositories;

public class CatalogItemRepository(CatalogDbContext context) 
    : BaseRepository<CatalogItem>(context), ICatalogItemRepository
{
    public async Task<CatalogItem?> GetByTitleAsync(string title, CancellationToken ct)
    {
        return await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Title == title, ct);
    }
}