using Checkout.Application.Features.Orders.CreateOrder;

namespace Checkout.Application.Orders.Commands.UpdateOrder.DTOs;

public record UpdateOrderDto(
    ContactDto? ContactInfo,
    AddressDto? DeliveryAddress,
    PaymentMethod? PaymentMethod,
    CardDetailsDto? CardDetails,
    OrderStatus? Status
);