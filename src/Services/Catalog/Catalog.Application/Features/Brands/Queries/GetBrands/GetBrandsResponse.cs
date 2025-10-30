namespace Catalog.Application.Features.Brands.Queries.GetBrands;

public record GetBrandsResponse(IReadOnlyList<Brand> Brands);