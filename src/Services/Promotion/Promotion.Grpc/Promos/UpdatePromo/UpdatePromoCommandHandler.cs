namespace Promotion.Grpc.Promos.UpdatePromo;

public class UpdatePromoCommandHandler(IPromoRepository repository)
    : ICommandHandler<UpdatePromoCommand, UpdatePromoResponse>
{
    public async Task<UpdatePromoResponse> Handle(UpdatePromoCommand command, CancellationToken cancellationToken)
    {
        var updatePromo = command.Request.Adapt<Promo>();
        
        var success = await repository.UpdateAsync(updatePromo);

        var result = new UpdatePromoResponse
        {
            Success = success,
            Message = success ? "Success update a promotion" : "Failed to update promotion"
        };
        
        return result;
    }
}