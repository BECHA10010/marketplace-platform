namespace Catalog.Application.Domains.Categories.Queries;

public sealed partial record GetCategoriesQuery
    : IRequest<OneOf<GetCategoriesQuery.Results.SuccessResult, GetCategoriesQuery.Results.FailResult>>;