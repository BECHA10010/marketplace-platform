namespace Catalog.Application.CatalogItems.Queries.GetPaginationCatalogItems;

public record GetPaginationCatalogItemsQuery(QueryArgs Args) : IQuery<GetPaginationCatalogItemsResponse>;