namespace Catalog.API.CatalogItems.Mappings;

public static class CatalogItemResponseMapping
{
    public static CatalogItemResponse ToResponse(this CatalogItemDto dto)
        => new (dto.Title, dto.Description, dto.Brand, dto.Category, dto.UnitPrice);
    
    public static List<CatalogItemResponse> ToResponseList(this IEnumerable<CatalogItemDto> dtos)
        => dtos.Select(dto => dto.ToResponse()).ToList();
}