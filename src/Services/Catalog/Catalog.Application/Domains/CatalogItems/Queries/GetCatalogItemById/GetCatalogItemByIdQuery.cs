namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemById;

public record GetCatalogItemByIdQuery(Guid Id) : IRequest<GetCatalogItemByIdResult>;