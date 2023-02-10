using Petshop.Core.Orders;
using Petshop.Core.Payments;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Payments.Query.PaymentRequest;

public class RequestPaymentQuery : IQuery<RequestPaymentResult>
{
    public int Id { get; set; }

}
