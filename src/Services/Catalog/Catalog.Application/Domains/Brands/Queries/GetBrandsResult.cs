namespace Catalog.Application.Domains.Brands.Queries;

public record GetBrandsResult(IEnumerable<Brand> Brands);