namespace Basket.API.ShoppingCarts.SaveCart;

public class SaveCartCommandHandler(
    IShoppingCartWriteRepository writeRepository,
    ICartPromotionService promotionService) : ICommandHandler<SaveCartCommand, SaveCartResult>
{
    public async Task<SaveCartResult> Handle(SaveCartCommand command, CancellationToken ct)
    {
        var cart = await writeRepository.GetByAccountNameAsync(command.AccountName, ct)
            ?? ShoppingCart.Create(command.AccountName);

        foreach (var item in command.CartItems)
            cart.AddItem(item.CatalogItemId, item.Title, item.Quantity, item.UnitPrice);
        
        await promotionService.ApplyPromotionsAsync(cart, ct);
        
        await writeRepository.SaveAsync(cart, ct);
        
        return new SaveCartResult(cart.Id);
    }
}

public record SaveCartCommand(string AccountName, List<SaveCartItemDto> CartItems) : ICommand<SaveCartResult>;
public record SaveCartItemDto(
    Guid CatalogItemId,
    string Title,
    int Quantity,
    decimal UnitPrice);

public record SaveCartResult(Guid Id);
