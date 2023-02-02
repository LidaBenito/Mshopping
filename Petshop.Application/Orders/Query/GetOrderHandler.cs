using Petshop.Contract.Orders;
using Petshop.Core.Orders;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Orders.Query;

class GetOrderHandler : QueryHandler<GetOrderQuery, Order>
{
	private readonly OrderRepository orderRepository;
	public GetOrderHandler(OrderRepository orderRepository)
	{
		this.orderRepository = orderRepository;
	}
	public override Task<Order> Handle(GetOrderQuery query, CancellationToken cancellationToken)
	{
		var order = orderRepository.GetOrder(query.OrderId);
		if (order == null)
		{
			return default;
		}
		return ResultAsync(order);

	}
}
