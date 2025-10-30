namespace Catalog.Application.Features.CatalogItems.Queries.GetPaginationCatalogItems;

public record GetPaginationCatalogItemsQuery(QueryArgs Args) : IQuery<GetPaginationCatalogItemsResponse>;