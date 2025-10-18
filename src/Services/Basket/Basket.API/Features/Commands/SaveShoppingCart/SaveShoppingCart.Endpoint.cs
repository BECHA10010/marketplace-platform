using Mapster;
using MediatR;

namespace Basket.API.Features.Commands.SaveShoppingCart;

public static partial class SaveShoppingCart
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (Request saveCartRequest, ISender sender) =>
            {
                var command = saveCartRequest.Adapt<Command>();
                var response = await sender.Send(command);
                
                return Results.Created($"/basket/{response.AccountName}", response);
            })
            .WithName("SaveShoppingCart")
            .Produces<Response>(StatusCodes.Status201Created)
            .WithSummary("Сохранение/обновление корзины")
            .WithDescription("Сохраняет/обновляет корзину пользователя и возвращает имя аккаунта");
        }
    }
}