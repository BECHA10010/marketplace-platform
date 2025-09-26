namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemsByBrand;

public record GetCatalogItemsByBrandResult(IEnumerable<CatalogItem> Result);