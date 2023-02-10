using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Orders.OrderInfos.Command;

public class DeleteOrderInfoCommand:ICommand<int>
{
	public int OrderInfoId{ get; set; }
}
