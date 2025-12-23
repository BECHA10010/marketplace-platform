namespace Catalog.API.Categories.Mappings;

public static class CategoryResponseMapping
{
    public static CategoryResponse ToResponse(this CategoryDto dto)
        => new (dto.Id, dto.Name);
    
    public static CatalogItemsResponse ToResponseList(this IEnumerable<CategoryDto> dtos)
        => new(dtos.Select(dto => dto.ToResponse()).ToList());
}