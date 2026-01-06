namespace Promotion.Grpc.Promos.GetPromoByCatalogItem;

public record GetPromoByCatalogItemQuery(string CatalogItemId) : IQuery<PromoModel>;