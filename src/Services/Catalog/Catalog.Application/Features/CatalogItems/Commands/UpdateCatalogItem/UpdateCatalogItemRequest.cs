namespace Catalog.Application.Features.CatalogItems.Commands.UpdateCatalogItem;

public record UpdateCatalogItemRequest(
    Guid Id,
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price);