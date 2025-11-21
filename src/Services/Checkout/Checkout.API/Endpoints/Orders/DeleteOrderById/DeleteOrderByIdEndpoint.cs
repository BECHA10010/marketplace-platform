namespace Checkout.API.Endpoints.Orders.DeleteOrderById;

public class DeleteOrderByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/", async ([AsParameters] DeleteOrderByIdRequest request, ISender sender) =>
        {
            var command = new DeleteOrderByIdCommand(request.OrderId);
            var result = await sender.Send(command);
            var response = new DeleteOrderByIdResponse(result.IsDeleted);
            
            return result.IsDeleted ? Results.Ok(response) : Results.NotFound(response);
        });
    }
}