namespace Checkout.API.Endpoints.Orders.GetOrdersByAccountName;

public class GetOrdersByAccountNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters] GetOrdersByAccountNameRequest request, ISender sender) =>
        {
            var query = new GetOrdersByAccountNameQuery(request.AccountName);
            var result = await sender.Send(query);
            var response = result.Adapt<GetOrdersByAccountNameResponse>();

            return Results.Ok(response);
        });
    }
}