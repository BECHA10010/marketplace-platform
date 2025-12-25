using Checkout.Application.Orders.Commands.RemoveOrder;

namespace Checkout.API.Orders.RemoveOrder;

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