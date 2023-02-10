using Petshop.Contract.Orders;
using Petshop.Contract.Payments;
using Petshop.Core.Payments;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Application.Payments.Command.PaymentSuccess;

class PaymentSuccessHandler : CommandHandler<PaymentSuccessCommand, VarifyPaymentResult>
{
	private readonly PaymentService paymentService;
	private readonly OrderRepository orderRepository;

	public PaymentSuccessHandler(PaymentService paymentService, OrderRepository orderRepository)
	{
		this.paymentService = paymentService;
		this.orderRepository = orderRepository;
	}
	public override Task<Result<VarifyPaymentResult>> Handle(PaymentSuccessCommand command, CancellationToken cancellationToken)
	{

		var verifyResult = paymentService.Varify(command.Token.ToString());
		if (verifyResult.IsCorrect)
		{
			orderRepository.SetPaymentDone(verifyResult.FactorNumber, verifyResult.TransId);
			verifyResult.Message = "پرداخت با موفقیت انجام شد .";
		}

		return OkAsyc(verifyResult);
	}
}
