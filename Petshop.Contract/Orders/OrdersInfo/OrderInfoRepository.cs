using Petshop.Core.Orders;

namespace Petshop.Contract.Orders.OrdersInfo;

public interface OrderInfoRepository
{
    List<OrderInfo> GetOrderInfos();
    OrderInfo GetOrderInfo(int id);
    void Delete(OrderInfo orderInfo);

	}
