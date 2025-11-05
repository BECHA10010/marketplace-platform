namespace Promotion.Grpc.UseCases.DeletePromo;

public class DeletePromoHandler(IPromoRepository repository)
    : ICommandHandler<DeletePromoCommand, DeletePromoResponse>
{
    public async Task<DeletePromoResponse> Handle(DeletePromoCommand command, CancellationToken cancellationToken)
    {
        var success = await repository.DeleteByCatalogItemIdAsync(command.CatalogItemId);

        return new DeletePromoResponse
        {
            Success = success,
            Description = success ? "Success delete a promotion" : "Failed to delete promotion"
        };
    }
}