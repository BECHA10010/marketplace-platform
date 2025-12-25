using Checkout.Application.Orders.Commands.UpdateOrder;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace Checkout.API.Orders.UpdateOrder;

public class UpdateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/orders/{id:guid}", async (Guid id, [FromBody] UpdateOrderRequest request, ISender sender) =>
        {
            var command = new UpdateOrderCommand(id, request.Adapt<UpdateOrderDto>());
            var result = await sender.Send(command);
            
            return result.IsUpdated 
                ? Results.NoContent() 
                : Results.NotFound();
        }).AddFluentValidationAutoValidation();
    }
}