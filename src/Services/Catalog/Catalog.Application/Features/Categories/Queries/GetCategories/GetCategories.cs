namespace Catalog.Application.Features.Categories.Queries.GetCategories;

public record GetCategoriesQuery() : IQuery<GetCategoriesResponse>;
public record GetCategoriesResponse(IReadOnlyList<Category> Categories);

public class GetCategoriesHandler(ICategoryRepository repository) 
    : IQueryHandler<GetCategoriesQuery, GetCategoriesResponse>
{
    public async Task<GetCategoriesResponse> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync(cancellationToken);
        
        return new GetCategoriesResponse(categories);
    }
}