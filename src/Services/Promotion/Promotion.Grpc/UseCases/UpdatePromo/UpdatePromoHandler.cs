namespace Promotion.Grpc.UseCases.UpdatePromo;

public class UpdatePromoHandler(IPromoRepository repository)
    : ICommandHandler<UpdatePromoCommand, UpdatePromoResponse>
{
    public async Task<UpdatePromoResponse> Handle(UpdatePromoCommand command, CancellationToken cancellationToken)
    {
        var updatePromo = new Promo
        {
            Id = Guid.Parse(command.Request.Id),
            Title = command.Request.Title,
            Value = (decimal)command.Request.Value
        };
        
        var success = await repository.UpdateAsync(updatePromo);

        var result = new UpdatePromoResponse
        {
            Success = success,
            Description = success ? "Success update a promotion" : "Failed to update promotion"
        };
        
        return result;
    }
}