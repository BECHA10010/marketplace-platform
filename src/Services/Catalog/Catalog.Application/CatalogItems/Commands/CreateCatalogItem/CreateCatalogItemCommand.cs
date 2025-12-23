namespace Catalog.Application.CatalogItems.Commands.CreateCatalogItem;

public record CreateCatalogItemCommand(CreateCatalogItemDto CreateData) : ICommand<CreateCatalogItemResult>;