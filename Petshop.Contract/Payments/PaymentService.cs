using Petshop.Core.Payments;

namespace Petshop.Contract.Payments
{
	public interface PaymentService
	{
	
		RequestPaymentResult Request(string amount, string mobile, string factorNumber, string Description);
		VarifyPaymentResult Varify(string transId);

	}
}
