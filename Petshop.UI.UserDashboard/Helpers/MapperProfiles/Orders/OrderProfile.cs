using Petshop.UI.UserDashboard.Models.Orders;

namespace Petshop.UI.UserDashboard.Helpers.MapperProfiles.Orders;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderListViewModel>();
        CreateMap<Order, OrderDetailsViewModel>();


    }
}
