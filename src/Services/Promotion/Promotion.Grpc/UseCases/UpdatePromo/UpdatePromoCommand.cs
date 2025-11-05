namespace Promotion.Grpc.UseCases.UpdatePromo;

public record UpdatePromoCommand(UpdatePromoRequest Request) : ICommand<UpdatePromoResponse>;