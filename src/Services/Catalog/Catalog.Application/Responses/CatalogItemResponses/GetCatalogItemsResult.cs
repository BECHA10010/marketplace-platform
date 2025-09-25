using Catalog.Domain.Entities;
using Catalog.Domain.Specifications;

namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemsResult(Pagination<CatalogItem> CatalogItems);