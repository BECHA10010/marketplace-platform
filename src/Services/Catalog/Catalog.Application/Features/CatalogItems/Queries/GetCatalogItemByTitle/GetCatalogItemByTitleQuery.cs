namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemByTitle;

public record GetCatalogItemByTitleQuery(string Title) : IQuery<GetCatalogItemByTitleResponse>;