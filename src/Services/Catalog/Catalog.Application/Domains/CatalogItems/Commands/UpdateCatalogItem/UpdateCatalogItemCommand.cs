namespace Catalog.Application.Domains.CatalogItems.Commands.UpdateCatalogItem;

public record UpdateCatalogItemCommand(
    Guid Id,
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price) : IRequest<UpdateCatalogItemResult>;