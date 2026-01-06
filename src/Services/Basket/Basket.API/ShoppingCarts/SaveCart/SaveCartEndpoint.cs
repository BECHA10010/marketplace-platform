namespace Basket.API.ShoppingCarts.SaveCart;

public class SaveCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async ([FromBody] SaveCartRequest request, ISender sender) =>
        {
            var command = request.ToCommand();
            var result = await sender.Send(command);
            var response = new SaveCartResponse(result.Id);
            
            return Results.Created($"/basket/{response.Id}", response);
        })
        .AddFluentValidationAutoValidation()
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Сохранение корзины");
    }
}

public record SaveCartRequest(string AccountName, List<CartItemRequest> CartItems);
public record CartItemRequest(Guid CatalogItemId, string Title, int Quantity, decimal UnitPrice);

public record SaveCartResponse(Guid Id);