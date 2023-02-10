using Petshop.Application.Payments.Command.PaymentFail;
using Petshop.Application.Payments.Command.PaymentSuccess;
using Petshop.Application.Payments.Query.PaymentRequest;

namespace Petshop.Endpoint.Controllers;

public class PaymentController : BaseController
{
    private readonly OrderRepository orderRepository;
    private readonly PaymentService paymentService;
    private readonly IConfiguration configuration;
	private readonly IMediator _mediator;
	public PaymentController(OrderRepository orderRepository, PaymentService paymentService, IConfiguration configuration, IMediator mediator)
	{
		this.orderRepository = orderRepository;
		this.paymentService = paymentService;
		this.configuration = configuration;
		_mediator = mediator;
	}
	[HttpPost]
    public IActionResult RequestPayment(int Id)
    {
        RequestPaymentQuery requestResult = new() { Id = Id };
        var result = _mediator.Send(requestResult).GetAwaiter().GetResult();
        if (result.IsNotNull())
        {
            return Redirect($"{configuration["payIr:PaymentUrl"]}{result.Token}");
        }

        return View(result);


    }
    public IActionResult Verify(RequestPaymentResult result)
    {
        if (result.IsCorrect) 
        {
            PaymentSuccessCommand payment = new();
            var verifyResult = _mediator.Send(payment).GetAwaiter().GetResult();
           
                return View("PaymentCompelete", verifyResult);
           
        }
        PaymentFailCommand paymentFail = new();

        var failResult = _mediator.Send(paymentFail).GetAwaiter().GetResult();
        return View(failResult);

    }
}
