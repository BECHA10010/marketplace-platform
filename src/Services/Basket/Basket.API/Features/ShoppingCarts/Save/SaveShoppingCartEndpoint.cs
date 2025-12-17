namespace Basket.API.Features.ShoppingCarts.Save;

public class SaveShoppingCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/save", async ([FromBody] SaveShoppingCartRequest request, ISender sender, IValidator<SaveShoppingCartRequest> validator) =>
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var command = request.ToCommand();
            var response = await sender.Send(command);
            
            return Results.Created($"/basket/{response.AccountName}", response);
        })
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Сохранение корзины")
        .WithDescription("Сохраняет корзину пользователя и возвращает имя аккаунта");
    }
}