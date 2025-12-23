namespace Catalog.Application.CatalogItems.Services;

public interface ICatalogItemsQueryService
{
    Task<IReadOnlyList<CatalogItemDto>> GetAllAsync(CancellationToken ct);
    Task<IReadOnlyList<CatalogItemDto>> GetByBrandAsync(string brandName, CancellationToken ct);
    Task<IReadOnlyList<CatalogItemDto>> GetByCategoryAsync(string categoryName, CancellationToken ct);
}