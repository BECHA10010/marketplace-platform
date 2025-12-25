using Common.Kernel.Domain.Abstractions.Repositories;

namespace Catalog.Application.Brands.Queries.GetBrands;

public class GetBrandsQueryHandler(IBrandRepository repository) 
    : IQueryHandler<GetBrandsQuery, GetBrandsResult>
{
    public async Task<GetBrandsResult> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
    {
        var brands = await repository.GetAllAsync(cancellationToken);
        var result = brands.Select(b => new BrandDto(b.Id, b.Name)).ToList();
        
        return new GetBrandsResult(result);
    }
}