namespace Catalog.Domain.Repositories;

public interface ICatalogItemRepository
{
    Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken);
    Task<Pagination<CatalogItem>> GetCatalogItemsAsync(QueryArgs args, CancellationToken cancellationToken);
    Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken cancellationToken);
    Task<CatalogItem?> GetCatalogItemByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IReadOnlyList<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellationToken);
    Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken);
    Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellationToken);
}