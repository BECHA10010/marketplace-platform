namespace Catalog.Application.Domains.CatalogItems.Commands.DeleteCatalogItemById;

public record DeleteCatalogItemByIdCommand(Guid Id) : IRequest<DeleteCatalogItemByIdResult>;