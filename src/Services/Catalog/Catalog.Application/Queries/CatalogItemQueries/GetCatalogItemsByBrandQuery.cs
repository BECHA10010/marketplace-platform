namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsByBrandQuery(string BrandTitle) : IRequest<GetCatalogItemsByBrandResult>;