using Catalog.Domain.CatalogItem;

namespace Catalog.Application.CatalogItems.Queries.GetPaginationCatalogItems;

public record GetPaginationCatalogItemsResponse(Pagination<CatalogItem> Pagination);