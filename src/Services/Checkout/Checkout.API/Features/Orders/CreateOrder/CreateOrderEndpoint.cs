namespace Checkout.API.Features.Orders.CreateOrder;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async ([FromBody] CreateOrderRequest request, ISender sender, IValidator<CreateOrderRequest> validator) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
            }
            
            var command = request.Adapt<CreateOrderCommand>();
            var result = await sender.Send(command);
            var response = new CreateOrderResponse(result.OrderId, result.Message);
            
            return Results.Created($"/orders/{response.OrderId}", response);
        });
    }
}