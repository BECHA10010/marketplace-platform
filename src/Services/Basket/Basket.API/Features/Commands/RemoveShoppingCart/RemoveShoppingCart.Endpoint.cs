namespace Basket.API.Features.Commands.RemoveShoppingCart;

public static partial class RemoveShoppingCart
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{accountName}", async ([AsParameters] RemoveShoppingCartRequest request, ISender sender) =>
            {
                var command = request.Adapt<RemoveShoppingCartCommand>();
                var response = await sender.Send(command);

                return Results.Ok(response);
            })
            .WithName("RemoveShoppingCart")
            .Produces<RemoveShoppingCartResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Удаление корзины")
            .WithDescription("Удаляет корзину пользователя по имени аккаунта");
        }
    }
}