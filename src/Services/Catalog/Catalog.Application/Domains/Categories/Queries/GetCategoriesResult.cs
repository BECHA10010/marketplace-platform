namespace Catalog.Application.Domains.Categories.Queries;

public record GetCategoriesResult(IEnumerable<Category> Categories);