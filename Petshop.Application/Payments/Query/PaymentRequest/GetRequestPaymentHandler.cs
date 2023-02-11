using Petshop.Contract.Orders;
using Petshop.Contract.Payments;
using Petshop.Core.Payments;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Payments.Query.PaymentRequest;

class GetRequestPaymentHandler : QueryHandler<GetRequestPaymentQuery, RequestPaymentResult>
{
    private readonly OrderRepository orderRepository;
    private readonly PaymentService paymentService;

    public GetRequestPaymentHandler(OrderRepository orderRepository, PaymentService paymentService)
    {
        this.orderRepository = orderRepository;
        this.paymentService = paymentService;
    }

    public override Task<RequestPaymentResult> Handle(GetRequestPaymentQuery query, CancellationToken cancellationToken)
    {
        var order = orderRepository.GetPaymentOrder(query.Id);
        var result = paymentService.Request(order.OrdersInfo.Sum(p => p.Product.Price).ToString(), "09121234567", order.Id.ToString(), order.Address);
        if (result.IsCorrect)
        {
            orderRepository.SetTransactionId(query.Id, result.Token, order.PaymentOrder.Id);
            return ResultAsync(result);
        }
        return ResultAsync(default);
    }
}
