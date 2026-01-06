namespace Catalog.Application.Brands.Queries.GetBrandById;

public record GetBrandByIdQuery(Guid Id) : IQuery<GetBrandByIdResult>;