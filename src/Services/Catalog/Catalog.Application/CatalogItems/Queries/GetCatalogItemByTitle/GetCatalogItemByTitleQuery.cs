namespace Catalog.Application.CatalogItems.Queries.GetCatalogItemByTitle;
public record GetCatalogItemByTitleQuery(string Title) : IQuery<GetCatalogItemByTitleResult>;