namespace Catalog.API.CatalogItems.Requests;

public record CreateCatalogItemRequest(
    string Title,
    string Description,
    string BrandName,
    string CategoryName,
    decimal Price
);