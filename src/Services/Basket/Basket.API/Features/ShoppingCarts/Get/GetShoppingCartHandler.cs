namespace Basket.API.Features.ShoppingCarts.Get;

public class GetShoppingCartHandler(IShoppingCartReadRepository repository)
    : IQueryHandler<GetShoppingCartQuery, ShoppingCartResponse>
{
    public async Task<ShoppingCartResponse> Handle(GetShoppingCartQuery query, CancellationToken ct)
    {
        var cart = await repository.GetByAccountNameAsync(query.AccountName, ct);

        return cart is null
            ? new ShoppingCartResponse(query.AccountName, 0, 0, [])
            : cart.ToResponse();
    }
}