namespace Basket.API.ShoppingCarts.GetCartByAccount;

public static class GetCartByAccountMapping
{
    public static ShoppingCartResultDto ToDto(this ShoppingCart cart)
    {
        var items = cart.Items.Select(i => 
            new CartItemResultDto(
                i.CatalogItemId, 
                i.Title, 
                i.Quantity, 
                i.UnitPrice,
                i.Discount,
                i.FinalPrice)).ToList();
        
        return new ShoppingCartResultDto(cart.AccountName, cart.TotalAmount, cart.TotalDiscount, items);
    }
    
    public static ShoppingCartResponse ToResponse(this ShoppingCartResultDto cartDto)
    {
        var items = cartDto.Items.Select(i => 
            new CartItemResponse(
                i.CatalogItemId, 
                i.Title, 
                i.Quantity, 
                i.UnitPrice,
                i.Discount,
                i.FinalPrice)).ToList();
        
        return new ShoppingCartResponse(cartDto.AccountName, cartDto.TotalAmount, cartDto.TotalDiscount, items);
    }
}