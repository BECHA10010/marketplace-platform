namespace Checkout.API.Orders.Endpoints;

public class RemoveOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/{id:guid}", async ([FromRoute] Guid id, ISender sender) =>
        {
            var command = new RemoveOrderCommand(id);
            var result = await sender.Send(command);
            
            return result.IsDeleted 
                ? Results.NoContent() 
                : Results.NotFound();
        });
    }
}