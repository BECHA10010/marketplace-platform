namespace Basket.API.ShoppingCarts.ClearCart;

public class ClearCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/clear/{id:guid}", async (Guid id, ISender sender) =>
        {
            var command = new ClearCartCommand(id);
            var result = await sender.Send(command);

            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound();
        })
        .Produces(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Очистка корзины");
    }
}