namespace Catalog.API.Categories.Mappings;

public static class CategoryRequestMapping
{
    public static CreateCategoryDto ToCreateDto(this CreateCategoryRequest request)
        => new(request.Name);
    
    public static UpdateCategoryDto ToUpdateDto(this UpdateCategoryRequest request)
        => new(request.NewName);
}