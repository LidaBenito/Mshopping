
using Petshop.Contract.Orders.OrdersInfo;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Application.Orders.OrderInfos.Command;

class DeleteOrderInfoHandler: CommandHandler<DeleteOrderInfoCommand,int>
{
	private readonly OrderInfoRepository orderInfoRepository;

	public DeleteOrderInfoHandler(OrderInfoRepository orderInfoRepository)
	{
		this.orderInfoRepository = orderInfoRepository;
	}

	public override Task<Result<int>> Handle(DeleteOrderInfoCommand command, CancellationToken cancellationToken)
	{

		var orderInfo = orderInfoRepository.GetOrderInfo(command.OrderInfoId);
		var orderId = orderInfo.OrderId;
		orderInfoRepository.Delete(orderInfo);
		return OkAsyc(orderId);
	}
}
