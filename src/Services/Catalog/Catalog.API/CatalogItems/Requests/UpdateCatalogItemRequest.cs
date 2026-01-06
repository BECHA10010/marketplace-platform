namespace Catalog.API.CatalogItems.Requests;

public record UpdateCatalogItemRequest(
    string? Title,
    string? Description,
    string? BrandName,
    string? CategoryName,
    decimal? Price
);