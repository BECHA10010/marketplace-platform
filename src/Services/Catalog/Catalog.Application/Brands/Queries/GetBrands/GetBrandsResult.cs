namespace Catalog.Application.Brands.Queries.GetBrands;

public record GetBrandsResult(IReadOnlyList<BrandDto> Brands);