namespace Catalog.Application.Categories.Queries.GetCategoryByName;

public record GetCategoryByNameQuery(string Name) : IQuery<GetCategoryByNameResult>;