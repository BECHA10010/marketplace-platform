namespace Basket.API.Features.ShoppingCarts.Clear;

public class ClearShoppingCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/{accountName}/clear", async (string accountName, ISender sender, IValidator<ClearShoppingCartRequest> validator) =>
        {
            var request = new ClearShoppingCartRequest(accountName);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);
            
            var command = new ClearShoppingCartCommand(accountName);
            var result = await sender.Send(command);
            var response = new ClearShoppingCartResponse(result.IsSuccess);

            return response.IsSuccess
                ? Results.NoContent()
                : Results.NotFound(new { Message = $"Cart for {accountName} was not found." });
        })
        .Produces(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Удаление корзины")
        .WithDescription("Удаляет корзину пользователя по имени аккаунта");
    }
}