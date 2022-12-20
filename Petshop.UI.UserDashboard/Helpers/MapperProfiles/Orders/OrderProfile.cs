using AutoMapper;
using Petshop.Core.Orders;
using Petshop.UI.UserDashboard.Models;

namespace Petshop.UI.UserDashboard.Helpers.MapperProfiles.Orders
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderListViewModel > ();


        }
    }
}
