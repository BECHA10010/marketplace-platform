using Common.Kernel.Domain.Abstractions.Repositories;

namespace Catalog.Domain.CatalogItem;

public interface ICatalogItemRepository : IRepository<CatalogItem>
{
    Task<CatalogItem?> GetByTitleAsync(string title, CancellationToken ct);
}