using Checkout.Application.Features.Orders.CreateOrder;

namespace Checkout.API.Features.Orders.CreateOrder;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async ([FromBody] CreateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateOrderCommand>();
            var result = await sender.Send(command);
            var response = new CreateOrderResponse(result.OrderId, result.Message);
            
            return Results.Created($"/orders/{response.OrderId}", response);
        });
    }
}