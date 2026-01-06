namespace Catalog.Application.Brands.Queries.GetBrandByName;

public class GetBrandByNameQueryHandler(IBrandRepository repository)
    : IQueryHandler<GetBrandByNameQuery, GetBrandByNameResult>
{
    public async Task<GetBrandByNameResult> Handle(GetBrandByNameQuery query, CancellationToken cancellationToken)
    {
        var brand = await repository.GetByNameAsync(query.Name, cancellationToken);
        
        if (brand is null)
            throw new NotFoundException(nameof(Brand), query.Name);

        var result = new BrandDto(brand.Id, brand.Name);
        
        return new GetBrandByNameResult(result);
    }
}