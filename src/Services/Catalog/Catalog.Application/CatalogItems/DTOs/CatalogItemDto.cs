namespace Catalog.Application.CatalogItems.DTOs;

public record CatalogItemDto(Guid Id, string Title, string Description, string Brand, string Category, decimal UnitPrice);