namespace Promotion.Grpc.UseCases.DeletePromo;

public record DeletePromoCommand(string CatalogItemId) : ICommand<DeletePromoResponse>;