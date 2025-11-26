using Checkout.Application.Orders.Commands.UpdateOrder;

namespace Checkout.API.Endpoints.Orders.UpdateOrder;

public class UpdateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async ([FromBody] UpdateOrderRequest request, ISender sender) =>
        {
            var command = new UpdateOrderCommand("", request.UpdateData); // Будет модель запроса с Id и изменениями
            var result = await sender.Send(command);
            var response = new UpdateOrderResponse(result.IsUpdated);
            
            return response.IsUpdated ? Results.Ok(response) : Results.NotFound(response);
        });
    }
}