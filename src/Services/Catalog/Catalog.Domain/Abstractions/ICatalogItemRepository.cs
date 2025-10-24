namespace Catalog.Domain.Abstractions;

public interface ICatalogItemRepository
{
    Task<CatalogItem> AddAsync(CatalogItem item, CancellationToken ct);
    Task<Pagination<CatalogItem>> GetAllAsync(QueryArgs args, CancellationToken ct);
    Task<IReadOnlyList<CatalogItem>> GetAllAsyncV2(CancellationToken ct);
    Task<CatalogItem?> GetAsync(Guid id, CancellationToken ct);
    Task<CatalogItem?> GetByTitleAsync(string title, CancellationToken ct);
    Task<IReadOnlyList<CatalogItem>> GetByBrandAsync(string brandTitle, CancellationToken ct);
    Task UpdateAsync(CatalogItem item, CancellationToken ct);
    Task DeleteAsync(Guid id, CancellationToken ct);
}