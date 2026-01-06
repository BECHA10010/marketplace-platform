namespace Catalog.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler(ICategoryRepository repository) 
    : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
{
    public async Task<GetCategoryByIdResult> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(query.Id, cancellationToken);

        if (category is null)
            throw new NotFoundException(nameof(Category), query.Id);

        var result = new CategoryDto(category.Id, category.Name);
        
        return new GetCategoryByIdResult(result);
    }
}