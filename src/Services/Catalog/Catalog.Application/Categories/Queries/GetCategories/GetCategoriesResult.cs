namespace Catalog.Application.Categories.Queries.GetCategories;

public record GetCategoriesResult(IReadOnlyList<CategoryDto> Categories);