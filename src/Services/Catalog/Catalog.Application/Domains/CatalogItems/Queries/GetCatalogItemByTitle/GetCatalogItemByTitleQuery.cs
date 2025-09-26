namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemByTitle;

public record GetCatalogItemByTitleQuery(string Title) : IRequest<GetCatalogItemByTitleResult>;