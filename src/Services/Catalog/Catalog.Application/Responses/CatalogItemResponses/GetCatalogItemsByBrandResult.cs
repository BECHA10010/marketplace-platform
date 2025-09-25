namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemsByBrandResult(IEnumerable<CatalogItem> Result);