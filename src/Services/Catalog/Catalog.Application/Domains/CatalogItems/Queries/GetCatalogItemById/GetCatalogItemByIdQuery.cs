namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemById;

public sealed partial record GetCatalogItemByIdQuery(Guid Id) 
    : IRequest<OneOf<GetCatalogItemByIdQuery.Results.SuccessResult, GetCatalogItemByIdQuery.Results.FailResult>>;