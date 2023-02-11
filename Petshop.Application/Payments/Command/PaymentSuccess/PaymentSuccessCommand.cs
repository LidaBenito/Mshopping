using Petshop.Core.Payments;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Payments.Command.PaymentSuccess;
public class PaymentSuccessCommand:ICommand<VarifyPaymentResult>
	{
	public int Status { get; set; }
	public string Token { get; set; }
	public bool IsCorrect { get; set; }
	public string ErrorMessage { get; set; }
	public string ErrorCode { get; set; }

      }

