namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItems;

public sealed partial record GetCatalogItemsQuery(QueryArgs Args) 
    : IRequest<OneOf<GetCatalogItemsQuery.Results.SuccessResult, GetCatalogItemsQuery.Results.FailResult>>;