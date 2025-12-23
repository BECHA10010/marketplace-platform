namespace Catalog.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler(IReadRepository<Category> repository) 
    : IQueryHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync(cancellationToken);

        var result = categories.Select(c => new CategoryDto(c.Id, c.Name)).ToList();
        
        return new GetCategoriesResult(result);
    }
}