using Mapster;
using MediatR;
using Results = Microsoft.AspNetCore.Http.Results;

namespace Basket.API.Features.Commands.RemoveShoppingCart;

public static partial class RemoveShoppingCart
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{accountName}", async ([AsParameters] Request removeCartRequest, ISender sender) =>
            {
                var command = removeCartRequest.Adapt<Command>();
                var response = await sender.Send(command);

                return Results.Ok(response);
            })
            .WithName("RemoveShoppingCart")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Удаление корзины")
            .WithDescription("Удаляет корзину пользователя по имени аккаунта");
        }
    }
}