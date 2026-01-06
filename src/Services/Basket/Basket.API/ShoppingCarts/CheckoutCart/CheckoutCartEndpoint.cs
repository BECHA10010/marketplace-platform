namespace Basket.API.ShoppingCarts.CheckoutCart;

public class CheckoutCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async ([FromBody] CheckoutCartRequest request, ISender sender) =>
        {
            var correlationId = Guid.NewGuid();
            
            var command = request.ToCommand(correlationId);
            var result = await sender.Send(command);
            var response = result.ToResponse();

            return Results.Ok(response);
        });
    }
}

public record CheckoutCartResponse(Guid CorrelationId, string Message);