namespace Basket.API.Features.ShoppingCarts.Commands.SaveShoppingCart;

public static partial class SaveShoppingCart
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (SaveShoppingCartRequest request, ISender sender) =>
            {
                var command = request.Adapt<SaveShoppingCartCommand>();
                var response = await sender.Send(command);
                
                return Results.Created($"/basket/{response.AccountName}", (object?)response);
            })
            .WithName("SaveShoppingCart")
            .Produces<SaveShoppingCartResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status409Conflict)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Сохранение корзины")
            .WithDescription("Сохраняет корзину пользователя и возвращает имя аккаунта");
        }
    }
}