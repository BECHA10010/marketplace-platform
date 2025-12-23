namespace Catalog.Application.CatalogItems.DTOs;

public record CatalogItemDto(string Title, string Description, string Brand, string Category, decimal UnitPrice);