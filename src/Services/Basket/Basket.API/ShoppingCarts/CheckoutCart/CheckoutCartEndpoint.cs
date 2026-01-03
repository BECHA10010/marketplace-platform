namespace Basket.API.ShoppingCarts.CheckoutCart;

public class CheckoutCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async ([FromBody] CheckoutCartRequest request, ISender sender) =>
        {
            var command = request.Adapt<CheckoutCartCommand>();
            var result = await sender.Send(command);
            var response = result.ToResponse();

            return Results.Ok(response);
        });
    }
}

public record CheckoutCartRequest(
    string AccountName,
    string FirstName,
    string LastName,
    string Email,
    string Street,
    string City,
    int PaymentMethod,
    string? CardNumber,
    string? Expiration,
    string? CvvCode
);

public record CheckoutCartResponse(Guid OrderId, string CorrelationId, string Message);