namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemById;

public record GetCatalogItemByIdQuery(Guid Id) : IQuery<GetCatalogItemByIdResponse>;