namespace Checkout.API.Endpoints.Orders.CreateOrder;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async ([FromBody] CreateOrderRequest request, ISender sender) =>
        {
            var command = new CreateOrderCommand(request.Order);
            var result = await sender.Send(command);
            var response = new CreateOrderResponse(result);
            
            return Results.Created($"/orders/{response.Result.OrderId}", response.Result);
        });
    }
}