using Checkout.Application.Features.Orders.GetOrdersByAccountName;

namespace Checkout.API.Features.Orders.GetOrdersByAccountName;

public class GetOrdersByAccountNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters] GetOrdersByAccountNameRequest request, ISender sender) =>
        {
            var query = new GetOrdersByAccountNameQuery(request.AccountName);
            var result = await sender.Send(query);
            
            var response = new GetOrdersByAccountNameResponse(
                request.AccountName,
                result.Orders.Adapt<List<OrderDataResponse>>());

            return Results.Ok(response);
        });
    }
}