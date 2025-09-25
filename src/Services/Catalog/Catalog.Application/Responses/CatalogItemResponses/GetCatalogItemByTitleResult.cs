using Catalog.Domain.Entities;

namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemByTitleResult(CatalogItem Result);