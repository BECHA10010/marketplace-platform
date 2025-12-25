namespace Promotion.Grpc.Promos.DeletePromo;

public class DeletePromoCommandHandler(IPromoRepository repository)
    : ICommandHandler<DeletePromoCommand, DeletePromoResponse>
{
    public async Task<DeletePromoResponse> Handle(DeletePromoCommand command, CancellationToken cancellationToken)
    {
        var success = await repository.DeleteByCatalogItemIdAsync(command.CatalogItemId);

        return new DeletePromoResponse
        {
            Success = success,
            Message = success ? "Success delete a promotion" : "Failed to delete promotion"
        };
    }
}