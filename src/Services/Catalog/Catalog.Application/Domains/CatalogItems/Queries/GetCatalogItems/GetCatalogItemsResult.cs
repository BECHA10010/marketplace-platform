namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItems;

public record GetCatalogItemsResult(Pagination<CatalogItem> CatalogItems);