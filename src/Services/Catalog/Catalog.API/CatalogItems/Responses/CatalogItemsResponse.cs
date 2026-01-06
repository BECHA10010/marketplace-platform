using Catalog.API.Categories.Responses;

namespace Catalog.API.CatalogItems.Responses;

public record CatalogItemsResponse(List<CategoryResponse> Items);