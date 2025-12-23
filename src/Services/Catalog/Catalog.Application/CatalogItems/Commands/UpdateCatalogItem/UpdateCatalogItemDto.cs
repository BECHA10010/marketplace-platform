namespace Catalog.Application.CatalogItems.Commands.UpdateCatalogItem;

public record UpdateCatalogItemDto(
    string? Title,
    string? Description,
    string? BrandName,
    string? CategoryName,
    decimal? Price
);