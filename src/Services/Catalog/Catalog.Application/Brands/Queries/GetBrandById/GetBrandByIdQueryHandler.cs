using Common.Kernel.Domain.Abstractions.Repositories;

namespace Catalog.Application.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryHandler(IBrandRepository repository) 
    : IQueryHandler<GetBrandByIdQuery, GetBrandByIdResult>
{
    public async Task<GetBrandByIdResult> Handle(GetBrandByIdQuery query, CancellationToken cancellationToken)
    {
        var brand = await repository.GetByIdAsync(query.Id, cancellationToken);

        if (brand is null)
            throw new NotFoundException(nameof(Brand), query.Id);

        var result = new BrandDto(brand.Id, brand.Name);
        
        return new GetBrandByIdResult(result);
    }
}