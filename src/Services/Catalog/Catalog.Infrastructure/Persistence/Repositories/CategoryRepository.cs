namespace Catalog.Infrastructure.Persistence.Repositories;

public class CategoryRepository(CatalogDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public async Task<Category?> GetByNameAsync(string name, CancellationToken ct)
    {
        return await Context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name == name, ct);
    }
}