

namespace Petshop.Endpoint.Helpers.MapProfiles.Payments;

public class PaymentProfile:Profile
{
	public PaymentProfile()
	{
		CreateMap<RequestPaymentResult, PaymentSuccessCommand>();
	}
}
