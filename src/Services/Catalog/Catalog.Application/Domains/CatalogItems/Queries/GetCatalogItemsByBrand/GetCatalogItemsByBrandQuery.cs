namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemsByBrand;

public record GetCatalogItemsByBrandQuery(string BrandTitle) : IRequest<GetCatalogItemsByBrandResult>;