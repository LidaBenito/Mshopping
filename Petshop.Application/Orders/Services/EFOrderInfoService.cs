using Petshop.Contract.Orders;
using Petshop.Contract.Orders.OrdersInfo;
using Petshop.Contract.Orders.Services;
using Petshop.Core.Products;

namespace Petshop.Application.Orders.Services;

public class EFOrderInfoService : OrderInfoService
{
	private readonly OrderInfoRepository orderInfoRepository;
	private readonly OrderRepository orderRepository;

	public EFOrderInfoService(OrderInfoRepository orderInfoRepository, OrderRepository orderRepository)
	{
		this.orderInfoRepository = orderInfoRepository;
		this.orderRepository = orderRepository;
	}



	public List<Product> GetProductsByOrders()
	{
		var ordersInfo = orderInfoRepository.GetOrderInfos();
		List<Product> currentProducts = new();
		foreach (var item in ordersInfo)
		{
			if (!currentProducts.Contains(item.Product))
			{
				currentProducts.Add(item.Product);

			}
		}
		return currentProducts;
	}
}
