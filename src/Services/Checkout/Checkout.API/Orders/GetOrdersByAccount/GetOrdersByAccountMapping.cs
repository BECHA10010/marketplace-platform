using Checkout.API.Orders.Common.Responses;
using Checkout.Application.Orders.DTOs;

namespace Checkout.API.Orders.GetOrdersByAccount;

public class GetOrdersByAccountMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderDto, OrderResponse>()
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