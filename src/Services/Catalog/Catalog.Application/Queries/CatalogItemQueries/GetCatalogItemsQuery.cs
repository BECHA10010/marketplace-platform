using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Specifications;
using MediatR;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsQuery(QueryArgs Args) : IRequest<GetCatalogItemsResult>;