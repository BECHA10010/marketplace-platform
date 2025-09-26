namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItems;

public record GetCatalogItemsQuery(QueryArgs Args) : IRequest<GetCatalogItemsResult>;