namespace Catalog.Application.Brands.Queries.GetBrandByName;

public record GetBrandByNameQuery(string Name) : IQuery<GetBrandByNameResult>;