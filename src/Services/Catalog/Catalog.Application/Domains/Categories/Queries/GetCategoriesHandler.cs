namespace Catalog.Application.Domains.Categories.Queries;

public class GetCategoriesHandler(ICategoryRepository repository) 
    : IRequestHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllCategoriesAsync();
        var result = new GetCategoriesResult(categories);
        
        return result;
    }
}