using Checkout.Application.Orders.Commands.CreateOrder;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace Checkout.API.Orders.CreateOrder;

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
        }).AddFluentValidationAutoValidation();
    }
}