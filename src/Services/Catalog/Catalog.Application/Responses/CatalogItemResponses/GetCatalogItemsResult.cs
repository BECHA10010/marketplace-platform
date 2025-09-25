namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemsResult(Pagination<CatalogItem> CatalogItems);