namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemByTitle;

public sealed partial record GetCatalogItemByTitleQuery(string Title) 
    : IRequest<OneOf<GetCatalogItemByTitleQuery.Results.SuccessResult, GetCatalogItemByTitleQuery.Results.FailResult>>;