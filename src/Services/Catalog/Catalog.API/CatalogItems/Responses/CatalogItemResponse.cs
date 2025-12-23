namespace Catalog.API.CatalogItems.Responses;

public record CatalogItemResponse(string Title, string Description, string Brand, string Category, decimal UnitPrice);