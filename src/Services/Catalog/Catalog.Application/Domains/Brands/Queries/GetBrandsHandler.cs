namespace Catalog.Application.Domains.Brands.Queries;

public class GetBrandsHandler(IBrandRepository repository) : IRequestHandler<GetBrandsQuery, GetBrandsResult>
{
    public async Task<GetBrandsResult> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
    {
        var brandList = await repository.GetAllBrandsAsync();
        var result = new GetBrandsResult(brandList);

        return result;
    }
}