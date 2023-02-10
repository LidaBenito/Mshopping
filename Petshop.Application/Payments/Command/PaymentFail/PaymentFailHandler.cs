using Petshop.Core.Payments;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Application.Payments.Command.PaymentFail;

class PaymentFailHandler : CommandHandler<PaymentFailCommand, RequestPaymentResult>
{
	public PaymentFailHandler()
	{

	}
	public override Task<Result<RequestPaymentResult>> Handle(PaymentFailCommand command, CancellationToken cancellationToken)
	{
		RequestPaymentResult result = new()
		{
			ErrorCode = "404",
			ErrorMessage = "پرداخت ناموفق !",
			Status = 0,
			Token = ""
		};
		
		return OkAsyc(result);
	}
}
