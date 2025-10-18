using Mapster;
using MediatR;

namespace Basket.API.Features.Queries.GetShoppingCart;

public static partial class GetShoppingCart
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{accountName}", async ([AsParameters] Request getCartRequest, ISender sender) => 
            {
                var query = getCartRequest.Adapt<Query>();
                var response = await sender.Send(query);
                
                return Results.Ok(response);
            })
            .WithName("GetShoppingCart")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Получение корзины")
            .WithDescription("Возвращает корзину пользователя по имени аккаунта");
        }
    }
}