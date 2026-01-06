namespace Catalog.Application.CatalogItems.Commands.UpdateCatalogItem;

public record UpdateCatalogItemCommand(Guid Id, UpdateCatalogItemDto UpdateCatalogItemDto) : ICommand;