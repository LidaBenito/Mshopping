using Petshop.Core.Orders;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Orders.Query;

public class GetOrderQuery:IQuery<Order>
{
	public int OrderId{ get; set; }
}
