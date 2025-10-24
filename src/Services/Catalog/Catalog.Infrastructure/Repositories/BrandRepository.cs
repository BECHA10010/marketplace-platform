namespace Catalog.Infrastructure.Repositories;

public class BrandRepository(IDocumentSession session) : IBrandRepository
{
    public async Task<IReadOnlyList<Brand>> GetAllAsync(CancellationToken ct)
    {
        return await session.Query<Brand>().ToListAsync(ct);
    }
}