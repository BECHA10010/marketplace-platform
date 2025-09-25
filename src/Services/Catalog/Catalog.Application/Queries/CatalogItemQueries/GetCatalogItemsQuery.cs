namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsQuery(QueryArgs Args) : IRequest<GetCatalogItemsResult>;