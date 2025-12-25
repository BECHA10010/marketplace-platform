namespace Catalog.Application.CatalogItems.Services;

public interface ICatalogItemQueryService
{
    Task<IReadOnlyList<CatalogItemDto>> GetAsync(string? brand, string? category, CancellationToken ct);
    Task<CatalogItemDto?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<CatalogItemDto?> GetByTitleAsync(string title, CancellationToken ct);
}