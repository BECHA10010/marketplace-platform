namespace Checkout.API.Features.Orders.UpdateOrder;

public class UpdateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/orders/{id}", async (string id, [FromBody] UpdateOrderRequest request, 
            ISender sender,
            IValidator<UpdateOrderRequest> validator) =>
        {
            if (!Guid.TryParse(id, out var guid))
                return Results.BadRequest(new { Message = "OrderId must be a valid GUID" });
            
            var validationResult = await validator.ValidateAsync(request);
            
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
            }
            
            var command = new UpdateOrderCommand(guid, request.Adapt<UpdateOrderDto>());
            var result = await sender.Send(command);
            var response = new UpdateOrderResponse(result.IsUpdated);
            
            return response.IsUpdated ? Results.Ok(response) : Results.NotFound(response);
        });
    }
}