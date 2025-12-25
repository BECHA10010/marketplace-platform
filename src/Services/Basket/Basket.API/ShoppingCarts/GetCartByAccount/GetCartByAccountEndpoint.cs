namespace Basket.API.ShoppingCarts.GetCartByAccount;

public class GetCartByAccountEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{accountName}", async (string accountName, ISender sender) =>
        {
            var query = new GetCartByAccountQuery(accountName);
            var result = await sender.Send(query);
            var response = result.Cart?.ToResponse();
            
            return Results.Ok(response); 
        })
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Получение корзины");
    }
}

public record ShoppingCartResponse(
    string AccountName, 
    decimal TotalAmount,
    decimal TotalDiscount,
    List<CartItemResponse> Items
);

public record CartItemResponse(
    Guid CatalogItemId,
    string Title, 
    int Quantity, 
    decimal UnitPrice,
    decimal Discount,
    decimal FinalPrice
);