namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemsByBrand;

public record GetCatalogItemsByBrandResponse(IReadOnlyList<CatalogItem> Items);