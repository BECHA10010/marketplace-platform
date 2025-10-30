namespace Catalog.Application.Features.Brands.Queries.GetBrands;

public class GetBrandsHandler(IBrandRepository repository) 
    : IQueryHandler<GetBrandsQuery, GetBrandsResponse>
{
    public async Task<GetBrandsResponse> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
    {
        var brands = await repository.GetAllAsync(cancellationToken);
        
        return new GetBrandsResponse(brands);
    }
}