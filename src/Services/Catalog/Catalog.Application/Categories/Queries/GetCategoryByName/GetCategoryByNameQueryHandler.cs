namespace Catalog.Application.Categories.Queries.GetCategoryByName;

public class GetCategoryByNameQueryHandler(ICategoryRepository repository)
    : IQueryHandler<GetCategoryByNameQuery, GetCategoryByNameResult>
{
    public async Task<GetCategoryByNameResult> Handle(GetCategoryByNameQuery query, CancellationToken cancellationToken)
    {
        var category = await repository.GetByNameAsync(query.Name, cancellationToken);
        
        if (category is null)
            throw new NotFoundException(nameof(Category), query.Name);

        var result = new CategoryDto(category.Id, category.Name);
        
        return new GetCategoryByNameResult(result);
    }
}