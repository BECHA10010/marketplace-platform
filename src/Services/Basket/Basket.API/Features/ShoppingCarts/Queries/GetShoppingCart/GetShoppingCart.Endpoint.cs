namespace Basket.API.Features.ShoppingCarts.Queries.GetShoppingCart;

public static partial class GetShoppingCart
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{accountName}", async ([AsParameters] GetShoppingCartRequest request, ISender sender) => 
            {
                var query = request.Adapt<GetShoppingCartQuery>();
                var response = await sender.Send(query);
                
                return Results.Ok((object?)response);
            })
            .WithName("GetShoppingCart")
            .Produces<GetShoppingCartResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Получение корзины")
            .WithDescription("Возвращает корзину пользователя по имени аккаунта");
        }
    }
}