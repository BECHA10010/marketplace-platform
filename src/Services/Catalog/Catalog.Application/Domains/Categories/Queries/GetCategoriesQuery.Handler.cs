namespace Catalog.Application.Domains.Categories.Queries;

public sealed partial record GetCategoriesQuery
{
    public sealed class Handler(ICategoryRepository repository)
        : IRequestHandler<GetCategoriesQuery, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = await repository.GetAllCategoriesAsync(cancellationToken);

            if (!categories.Any())
                return NotFound();
            
            return Success(categories);
        }
    }
}