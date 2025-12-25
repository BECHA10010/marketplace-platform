namespace Promotion.Grpc.Promos.UpdatePromo;

public record UpdatePromoCommand(UpdatePromoRequest Request) : ICommand<UpdatePromoResponse>;