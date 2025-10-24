namespace Catalog.Application.Features.CatalogItems.Commands.SaveCatalogItem;

public record CreateCatalogItemCommand(
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price) : ICommand<CreateCatalogItemResponse>;