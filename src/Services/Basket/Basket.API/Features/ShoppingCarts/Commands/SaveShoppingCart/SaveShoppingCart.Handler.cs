namespace Basket.API.Features.ShoppingCarts.Commands.SaveShoppingCart;
 
public static partial class SaveShoppingCart
{
    public class Handler(IShoppingCartRepository repository, PromoService.PromoServiceClient promoService) 
        : ICommandHandler<SaveShoppingCartCommand, SaveShoppingCartResponse>
    {
         public async Task<SaveShoppingCartResponse> Handle(SaveShoppingCartCommand command, CancellationToken cancellationToken)
         {
             var cart = command.Cart;

             await ApplyPromotionsToCartAsync(cart, cancellationToken);
             await repository.AddAsync(cart, cancellationToken);
             
             return new SaveShoppingCartResponse(cart.AccountName);
         }

         private async Task ApplyPromotionsToCartAsync(ShoppingCart cart, CancellationToken cancellationToken)
         {
             foreach (var item in cart.Items)
             {
                 var discount = await GetDiscountForItemAsync(item, cancellationToken);
                 
                 item.Price -= (decimal)discount.Value;
             }
         }

         private async Task<PromoModel> GetDiscountForItemAsync(ShoppingCartItem item, CancellationToken cancellationToken)
         {
             var getPromoRequest = new GetPromoRequest
             {
                 CatalogItemId = item.Id.ToString()
             };
                 
             return await promoService.GetPromoAsync(getPromoRequest, cancellationToken: cancellationToken);
         }
    }
}