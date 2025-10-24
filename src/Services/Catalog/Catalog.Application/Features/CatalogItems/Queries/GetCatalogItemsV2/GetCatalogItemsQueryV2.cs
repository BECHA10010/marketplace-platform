namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemsV2;

public record GetCatalogItemsQueryV2(QueryArgs Args) : IQuery<GetCatalogItemsResponseV2>;