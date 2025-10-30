namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItems;

public record GetCatalogItemsResponse(IReadOnlyList<CatalogItem> CatalogItems);