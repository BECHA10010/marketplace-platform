using Checkout.Application.Features.Orders.Common.DTOs;

namespace Checkout.Application.Features.Orders.GetOrdersByAccountName;

public class GetOrdersByAccountNameMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Order, OrderDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.AccountName, src => src.AccountName)
            .Map(dest => dest.Amount, src => src.TotalAmount)
            .Map(dest => dest.Status, src => src.Status.ToString())
            .Map(dest => dest.Items, src => 
                src.Items.Select(item => new OrderItemDto(item.ProductName, item.Quantity, item.UnitPrice)).ToList())
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod.ToString())
            .Map(dest => dest.PaymentStatus, src => src.PaymentStatus.ToString())
            .Map(dest => dest.CreatedAt, src => src.CreatedAt);
            
        config.NewConfig<DeliveryAddress, AddressDto>();
    }
}