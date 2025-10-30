namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository(IDocumentSession session) : ICategoryRepository
{
    public async Task<IReadOnlyList<Category>> GetAllAsync(CancellationToken ct)
    {
        return await session.Query<Category>().ToListAsync(ct);
    }
}