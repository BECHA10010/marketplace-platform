namespace Catalog.Domain.Repositories;

public interface ICatalogItemRepository
{
    Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item);
    Task<Pagination<CatalogItem>> GetCatalogItemsAsync(QueryArgs args);
    Task<CatalogItem?> GetCatalogItemAsync(Guid id);
    Task<CatalogItem?> GetCatalogItemByTitleAsync(string title);
    Task<IReadOnlyList<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle);
    Task<bool> UpdateCatalogItemAsync(CatalogItem item);
    Task<bool> DeleteCatalogItemAsync(Guid id);
}