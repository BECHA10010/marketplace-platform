namespace Basket.API.Features.ShoppingCarts.Get;

public class GetShoppingCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{accountName}", async (string accountName, ISender sender, IValidator<GetShoppingCartRequest> validator) =>
        {
            var request = new GetShoppingCartRequest(accountName);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Results.BadRequest(
                    validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var query = new GetShoppingCartQuery(accountName);
            var response = await sender.Send(query);
            
            return Results.Ok(response);
        })
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Получение корзины")
        .WithDescription("Возвращает корзину пользователя по аккаунту");
    }
}