using Petshop.Contract.Orders;
using Petshop.Core.Orders;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Orders.Query.Dashboard;

public class GetAllOrderListHandler : QueryHandler<GetAllOrderListQuery, List<Order>>
{
    private readonly OrderRepository orderRepository;
   
    public GetAllOrderListHandler(OrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
 
    }

    public override Task<List<Order>> Handle(GetAllOrderListQuery query, CancellationToken cancellationToken)
    {
        var orders = orderRepository.GetUnsendOrders();
        return ResultAsync(orders);
    }
}
