namespace Petshop.Endpoint.Controllers;

public class PaymentController : BaseController
{
   
    private readonly IConfiguration configuration;
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	public PaymentController(IConfiguration configuration, IMediator mediator, IMapper mapper)
	{
		this.configuration = configuration;
		_mediator = mediator;
		_mapper = mapper;
	}
	[HttpPost]
    public IActionResult RequestPayment(int Id)
    {
        GetRequestPaymentQuery requestResult = new() { Id = Id };
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
            PaymentSuccessCommand payment = _mapper.Map<PaymentSuccessCommand>(result);
            var verifyResult = _mediator.Send(payment).GetAwaiter().GetResult();
           
                return View("PaymentCompelete", verifyResult);
           
        }
        PaymentFailCommand paymentFail = new();

        var failResult = _mediator.Send(paymentFail).GetAwaiter().GetResult();
        return View(failResult);

    }
}
