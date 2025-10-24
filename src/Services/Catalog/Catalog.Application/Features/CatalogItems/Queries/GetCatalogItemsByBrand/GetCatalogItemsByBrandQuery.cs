namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemsByBrand;

public record GetCatalogItemsByBrandQuery(string BrandTitle) : IQuery<GetCatalogItemsByBrandResponse>;