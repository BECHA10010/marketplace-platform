namespace Basket.API.Features.ShoppingCarts.Clear;

public class ClearShoppingCartHandler(IShoppingCartWriteRepository writeRepository)
    : ICommandHandler<ClearShoppingCartCommand, ClearShoppingCartResponse>
{
    public async Task<ClearShoppingCartResponse> Handle(ClearShoppingCartCommand command, CancellationToken ct)
    {
        var cart = await writeRepository.GetByAccountNameAsync(command.AccountName, ct);

        if (cart is null)
            return new ClearShoppingCartResponse(false);
        
        cart.Clear();
        
        await writeRepository.SaveAsync(cart, ct);
        
        return new ClearShoppingCartResponse(true);
    }
}