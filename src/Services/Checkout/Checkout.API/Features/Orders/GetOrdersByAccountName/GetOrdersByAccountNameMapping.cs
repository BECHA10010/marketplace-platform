using Checkout.Application.Features.Orders.CreateOrder;
using Checkout.Application.Features.Orders.GetOrdersByAccountName;

namespace Checkout.API.Features.Orders.GetOrdersByAccountName;

public class GetOrdersByAccountNameMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderDto, OrderDataResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod)
            .Map(dest => dest.PaymentStatus, src => src.PaymentStatus)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToString("hh:mm dd-MM-yyyy"));
        
        config.NewConfig<AddressDto, AddressDataResponse>();
        config.NewConfig<OrderItemDto, OrderItemResponse>();
    }
}