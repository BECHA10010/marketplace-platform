namespace Basket.API.Features.ShoppingCarts.Shared.DTOs;

public record ShoppingCartResponse(
    string AccountName, 
    decimal TotalAmount,
    decimal TotalDiscount,
    List<CartItemResponse> Items
);