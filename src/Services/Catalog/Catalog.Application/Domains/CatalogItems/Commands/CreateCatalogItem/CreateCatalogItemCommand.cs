namespace Catalog.Application.Domains.CatalogItems.Commands.CreateCatalogItem;

public record CreateCatalogItemCommand(
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price) : IRequest<CreateCatalogItemResult>;