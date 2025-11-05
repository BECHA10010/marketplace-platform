namespace Promotion.Grpc.UseCases.CreatePromo;

public class CreatePromoHandler(IPromoRepository repository)
    : ICommandHandler<CreatePromoCommand, CreatePromoResponse>
{
    public async Task<CreatePromoResponse> Handle(CreatePromoCommand command, CancellationToken cancellationToken)
    {
        var promo = command.Promo.Adapt<Promo>();

        var success = await repository.CreateAsync(promo);

        var result = new CreatePromoResponse
        {
            Id = promo.Id.ToString(),
            Success = success,
            Description = success ? "Success create a promotion" : "Failed to create promotion"
        };
        
        return result;
    }
}