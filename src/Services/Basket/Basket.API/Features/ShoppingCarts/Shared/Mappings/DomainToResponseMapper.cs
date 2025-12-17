namespace Basket.API.Features.ShoppingCarts.Shared.Mappings;

public static class DomainToResponseMapper
{
    public static ShoppingCartResponse ToResponse(this ShoppingCart cart)
    {
        var items = cart.Items.Select(i => new CartItemResponse(
            i.CatalogItemId, 
            i.Title, 
            i.Quantity, 
            i.UnitPrice,
            i.Discount,
            i.FinalPrice)).ToList();
        
        return new ShoppingCartResponse(cart.AccountName, cart.TotalAmount, cart.TotalDiscount, items);
    }
}