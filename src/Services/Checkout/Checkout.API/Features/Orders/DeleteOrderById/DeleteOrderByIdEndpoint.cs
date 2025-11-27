using Checkout.Application.Features.Orders.DeleteOrderById;

namespace Checkout.API.Features.Orders.DeleteOrderById;

public class DeleteOrderByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/{id}", async (string id, ISender sender) =>
        {
            if (!Guid.TryParse(id, out var guid))
                return Results.BadRequest(new { Message = "OrderId must be a valid GUID" });
            
            var command = new DeleteOrderByIdCommand(guid);
            var result = await sender.Send(command);
            
            return result.IsDeleted 
                ? Results.NoContent() 
                : Results.NotFound(new { Message = $"Order with id: {id} was not found." });
        });
    }
}