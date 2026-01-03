namespace Basket.API.ShoppingCarts.ClearCart;

public class ClearCartCommandHandler(IShoppingCartWriteRepository writeRepository)
    : ICommandHandler<ClearCartCommand, ClearCartResult>
{
    public async Task<ClearCartResult> Handle(ClearCartCommand command, CancellationToken ct)
    {
        var cart = await writeRepository.GetByAccountNameAsync(command.AccountName, ct);

        if (cart is null)
            return new ClearCartResult(false);
        
        cart.Clear();
        
        await writeRepository.SaveAsync(cart, ct);
        
        return new ClearCartResult(true);
    }
}

public record ClearCartCommand(string AccountName) : ICommand<ClearCartResult>;
public record ClearCartResult(bool IsSuccess);