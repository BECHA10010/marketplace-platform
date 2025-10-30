namespace Catalog.Application.Features.Categories.Queries.GetCategories;

public record GetCategoriesResponse(IReadOnlyList<Category> Categories);