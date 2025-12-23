namespace Catalog.Application.CatalogItems.Commands.RemoveCatalogItem;

public record RemoveCatalogItemCommand(Guid Id) : ICommand;