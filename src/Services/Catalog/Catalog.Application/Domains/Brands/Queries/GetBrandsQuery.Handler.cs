namespace Catalog.Application.Domains.Brands.Queries;

public sealed partial record GetBrandsQuery
{
    public sealed class Handler(IBrandRepository repository)
        : IRequestHandler<GetBrandsQuery, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
        {
            var brands = await repository.GetAllBrandsAsync(cancellationToken);

            if (!brands.Any())
                return NotFound();
            
            return Success(brands);
        }
    }
}