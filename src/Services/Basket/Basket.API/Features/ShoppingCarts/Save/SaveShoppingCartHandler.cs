using Basket.API.Domain.ShoppingCart;

namespace Basket.API.Features.ShoppingCarts.Save;

public class SaveShoppingCartHandler(
    IShoppingCartWriteRepository writeRepository,
    ICartPromotionService promotionService) : ICommandHandler<SaveShoppingCartCommand, SaveShoppingCartResponse>
{
    public async Task<SaveShoppingCartResponse> Handle(SaveShoppingCartCommand command, CancellationToken ct)
    {
        var cart = await writeRepository.GetByAccountNameAsync(command.AccountName, ct)
            ?? ShoppingCart.Create(command.AccountName);

        foreach (var item in command.CartItems)
            cart.AddItem(item.CatalogItemId, item.Title, item.Quantity, item.UnitPrice);
        
        await promotionService.ApplyPromotionsAsync(cart, ct);
        
        await writeRepository.SaveAsync(cart, ct);
        
        return new SaveShoppingCartResponse(cart.AccountName);
    }
}