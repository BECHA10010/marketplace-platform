namespace Catalog.Application.CatalogItems.Queries.GetCatalogItems;

public record GetCatalogItemsQuery(string? Brand, string? Category) : IQuery<GetCatalogItemsResult>;