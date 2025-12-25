namespace Catalog.API.CatalogItems.Responses;

public record CatalogItemResponse(Guid Id, string Title, string Description, string Brand, string Category, decimal UnitPrice);