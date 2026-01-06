namespace Catalog.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IQuery<GetCategoryByIdResult>;