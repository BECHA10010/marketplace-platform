using Catalog.Domain.Entities;
using Marten;
using Marten.Schema;

namespace Catalog.Infrastructure.Data.Seed;

public class InitializeDatabaseAsync : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (!await session.Query<Brand>().AnyAsync(cancellation))
        {
            session.Store<Brand>(InitialData.Brands);
            await session.SaveChangesAsync(cancellation);
        }
        
        if (!await session.Query<Category>().AnyAsync(cancellation))
        {
            session.Store<Category>(InitialData.Categories);
            await session.SaveChangesAsync(cancellation);
        }
        
        if (!await session.Query<CatalogItem>().AnyAsync(cancellation))
        {
            session.Store<CatalogItem>(InitialData.CatalogItems);
            await session.SaveChangesAsync(cancellation);
        }
    }
}