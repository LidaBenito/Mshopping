using Petshop.Contract.Orders;
using Petshop.Core.Orders;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Orders.Query.Dashboard;

public class GetOrdersListHandler : QueryHandler<GetOrdersListQuery, List<Order>>
{
    private readonly OrderRepository orderRepository;
   
    public GetOrdersListHandler(OrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
 
    }

    public override Task<List<Order>> Handle(GetOrdersListQuery query, CancellationToken cancellationToken)
    {
        var orders = orderRepository.GetUnsendOrders();
        return ResultAsync(orders);
    }
}
