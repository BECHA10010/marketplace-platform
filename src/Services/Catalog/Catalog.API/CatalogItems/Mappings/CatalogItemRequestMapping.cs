namespace Catalog.API.CatalogItems.Mappings;

public static class CatalogItemRequestMapping
{
    public static CreateCatalogItemDto ToCreateDto(this CreateCatalogItemRequest request)
        => new(
            request.Title,
            request.Description,
            request.BrandName,
            request.CategoryName,
            request.Price
        );
    
    public static UpdateCatalogItemDto ToUpdateDto(this UpdateCatalogItemRequest request)
        => new(
            request.Title,
            request.Description,
            request.BrandName,
            request.CategoryName,
            request.Price
        );
}