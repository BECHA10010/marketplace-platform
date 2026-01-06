namespace Checkout.API.Orders.Endpoints;

public class GetOrdersByAccountEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{account}", async ([FromRoute] string account, ISender sender) =>
        {
            var query = new GetOrdersByAccountQuery(account);
            var result = await sender.Send(query);
            var response = new GetOrdersByAccountResponse(
                account, 
                result.Orders.Select(order => order.ToResponse()).ToList()
            );

            return Results.Ok(response);
        });
    }
}