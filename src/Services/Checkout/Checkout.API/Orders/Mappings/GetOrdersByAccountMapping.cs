namespace Checkout.API.Orders.Mappings;

public static class GetOrdersByAccountMapping
{
    public static OrderResponse ToResponse(this OrderDto dto)
    {
        return new OrderResponse(
            dto.Id,
            dto.TotalAmount,
            dto.Status,
            new DeliveryAddressResponse(dto.Address.Street, dto.Address.City),
            dto.PaymentMethod,
            dto.PaymentStatus,
            dto.Items.Select(item => new OrderItemResponse(item.Title, item.Quantity, item.UnitPrice)).ToList()
        );
    }
}