using Catalog.Domain.Brand;

namespace Catalog.Application.Features.Brands.Queries.GetBrands;

public class GetBrandsQueryHandler(IBrandRepository repository) 
    : IQueryHandler<GetBrandsQuery, GetBrandsResult>
{
    public async Task<GetBrandsResult> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
    {
        var brands = await repository.GetAllAsync(cancellationToken);
        
        return new GetBrandsResult(brands);
    }
}