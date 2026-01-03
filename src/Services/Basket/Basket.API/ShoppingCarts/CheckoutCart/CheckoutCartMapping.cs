using Basket.API.ShoppingCarts.GetCartByAccount;
using Common.Messaging.DTOs;
using Common.Messaging.Events;

namespace Basket.API.ShoppingCarts.CheckoutCart;

public static class CheckoutCartMapping
{
    public static OrderSubmittedEvent ToEvent(this CheckoutCartCommand command, ShoppingCartResultDto cart)
    {
        
        return new OrderSubmittedEvent
        {
            AccountName = command.AccountName,
            TotalAmount = cart.TotalAmount,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Street = command.Street,
            City = command.City,
            PaymentMethod = command.PaymentMethod,
            CardNumber = command.CardNumber,
            Expiration = command.Expiration,
            CvvCode = command.CvvCode,
            Items = cart.Items.Select(item => item.ToEventDto()).ToList()
        };
    }
    
    public static OrderItemEventDto ToEventDto(this CartItemResultDto cartItem)
    {
        return new OrderItemEventDto
        {
            Title = cartItem.Title,
            Quantity = cartItem.Quantity,
            UnitPrice = cartItem.UnitPrice
        };
    }
    
    public static CheckoutCartCommand ToCommand(this CheckoutCartRequest request)
    {
        var correlationId = Guid.NewGuid().ToString();
        
        return new CheckoutCartCommand
        (
            request.AccountName,
            request.FirstName,
            request.LastName,
            request.Email,
            request.Street,
            request.City,
            request.PaymentMethod,
            request.CardNumber,
            request.Expiration,
            request.CvvCode,
            correlationId
        );
    }

    public static CheckoutCartResponse ToResponse(this CheckoutCartResult result)
    {
        return new CheckoutCartResponse
        (
            result.OrderId,
            result.CorrelationId,
            result.Removed ? "Удалено" : "Не удалено"
        );
    }
}