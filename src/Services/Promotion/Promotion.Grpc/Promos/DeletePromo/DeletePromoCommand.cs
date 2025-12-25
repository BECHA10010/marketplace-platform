namespace Promotion.Grpc.Promos.DeletePromo;

public record DeletePromoCommand(string CatalogItemId) : ICommand<DeletePromoResponse>;