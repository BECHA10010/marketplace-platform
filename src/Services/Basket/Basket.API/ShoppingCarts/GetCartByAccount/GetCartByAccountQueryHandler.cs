namespace Basket.API.ShoppingCarts.GetCartByAccount;

public class GetCartByAccountQueryHandler(IShoppingCartReadRepository readRepository)
    : IQueryHandler<GetCartByAccountQuery, GetCartByAccountResult>
{
    public async Task<GetCartByAccountResult> Handle(GetCartByAccountQuery query, CancellationToken ct)
    {
        var cart = await readRepository.GetByAccountNameAsync(query.AccountName, ct);

        return cart is null
            ? new GetCartByAccountResult(null)
            : new GetCartByAccountResult(cart.ToDto());
    }
}

public record GetCartByAccountQuery(string AccountName) : IQuery<GetCartByAccountResult>;
public record GetCartByAccountResult(ShoppingCartResultDto? Cart);

public record ShoppingCartResultDto(
    string AccountName, 
    decimal TotalAmount,
    decimal TotalDiscount,
    IReadOnlyList<CartItemResultDto> Items
);

public record CartItemResultDto(
    Guid CatalogItemId,
    string Title, 
    int Quantity, 
    decimal UnitPrice,
    decimal Discount,
    decimal FinalPrice
);