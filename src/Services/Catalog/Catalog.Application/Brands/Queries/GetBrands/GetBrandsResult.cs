using Catalog.Domain.Brand;

namespace Catalog.Application.Features.Brands.Queries.GetBrands;

public record GetBrandsResult(IReadOnlyList<Brand> Brands);