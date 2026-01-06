namespace Catalog.Application.CatalogItems.Commands.CreateCatalogItem;

public record CreateCatalogItemDto(
    string Title,
    string Description,
    string Brand,
    string Category,
    decimal Price
);