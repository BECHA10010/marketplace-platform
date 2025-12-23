namespace Catalog.Application.CatalogItems.Queries.GetCatalogItems;

public record GetCatalogItemsResult(IReadOnlyList<CatalogItemDto> Items);