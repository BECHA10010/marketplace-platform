namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemsByBrand;

public sealed partial record GetCatalogItemsByBrandQuery(string BrandTitle)
    : IRequest<OneOf<GetCatalogItemsByBrandQuery.Results.SuccessResult, GetCatalogItemsByBrandQuery.Results.FailResult>>;
