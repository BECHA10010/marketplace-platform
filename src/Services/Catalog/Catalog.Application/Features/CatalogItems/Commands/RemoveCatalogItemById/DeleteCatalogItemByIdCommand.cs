namespace Catalog.Application.Features.CatalogItems.Commands.RemoveCatalogItemById;

public record DeleteCatalogItemByIdCommand(Guid Id) : ICommand<DeleteCatalogItemByIdResponse>;