namespace Catalog.Application.Domains.Brands.Queries;

public sealed partial record GetBrandsQuery
    : IRequest<OneOf<GetBrandsQuery.Results.SuccessResult, GetBrandsQuery.Results.FailResult>>;