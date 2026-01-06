namespace Promotion.Grpc.Promos.CreatePromo;

public record CreatePromoCommand(CreatePromoRequest Promo) : ICommand<CreatePromoResponse>;