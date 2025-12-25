namespace Basket.API.ShoppingCarts.ClearCart;

public class ClearCartCommandHandler(IShoppingCartWriteRepository writeRepository)
    : ICommandHandler<ClearCartCommand, ClearCartResult>
{
    public async Task<ClearCartResult> Handle(ClearCartCommand command, CancellationToken ct)
    {
        var cart = await writeRepository.GetByIdAsync(command.Id, ct);

        if (cart is null)
            return new ClearCartResult(false);
        
        cart.Clear();
        
        await writeRepository.SaveAsync(cart, ct);
        
        return new ClearCartResult(true);
    }
}

public record ClearCartCommand(Guid Id) : ICommand<ClearCartResult>;
public record ClearCartResult(bool IsSuccess);