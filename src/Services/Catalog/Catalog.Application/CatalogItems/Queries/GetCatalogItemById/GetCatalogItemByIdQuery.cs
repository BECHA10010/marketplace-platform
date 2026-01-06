namespace Catalog.Application.CatalogItems.Queries.GetCatalogItemById;

public record GetCatalogItemByIdQuery(Guid Id) : IQuery<GetCatalogItemByIdResult>;