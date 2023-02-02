

using Petshop.Application.Orders.Command;

namespace Petshop.Endpoint.Helpers.MapProfiles.Orders;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, CheckoutViewModel>();
        CreateMap<CheckoutViewModel,Order>();
        CreateMap<CheckoutViewModel, CheckoutOrderCommand>();
        CreateMap<int, AddBasketCommand>();
    }
}
