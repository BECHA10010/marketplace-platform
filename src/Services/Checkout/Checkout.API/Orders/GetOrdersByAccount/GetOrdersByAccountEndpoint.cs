using Checkout.API.Orders.Common.Responses;
using Checkout.Application.Orders.Queries.GetOrdersByAccount;

namespace Checkout.API.Orders.GetOrdersByAccount;

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
                result.Orders.Adapt<List<OrderResponse>>());

            return Results.Ok(response);
        });
    }
}