using Petshop.Contract.Orders;
using Petshop.Core.Baskets;
using Petshop.Core.Orders;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Application.Orders.Command;

class CheckoutOrderHandler : CommandHandler<CheckoutOrderCommand, int>
{
	private readonly OrderRepository orderRepository;
	private readonly Basket basket;
	public CheckoutOrderHandler(Basket basket, OrderRepository orderRepository)
	{
		this.basket = basket;
		this.orderRepository = orderRepository;
	}
	public override Task<Result<int>> Handle(CheckoutOrderCommand command, CancellationToken cancellationToken)
	{
		Order order = new();
		if (command is not null)
		{


			order.FullName = command.FullName;
			order.Address = command.Address;
			order.Address2 = command.Address2;
			order.City = command.City;
			order.Country = command.Country;
			order.GiftWrap = command.GiftWrap;
			order.Zip = command.Zip;
			order.State = command.State;
			order.PaymentOrder = new PaymentOrder
			{
				PaymentDate = DateTime.Today,

			};
			orderRepository.Save(order);
			AddOrderDetails(command, order);
			orderRepository.UpdateOrder(order);

			basket.Clear();
		}


		return OkAsyc(order.Id);
	}

	private void AddOrderDetails(CheckoutOrderCommand command, Order order)
	{

		order.OrdersInfo = new List<OrderInfo>();
		foreach (var item in basket.Items)
		{
			order.OrdersInfo.Add(new OrderInfo
			{
				Product = item.Product,
				Quantity = item.Quantity,

				OrderId = command.Id
			});
		}
	}
}
