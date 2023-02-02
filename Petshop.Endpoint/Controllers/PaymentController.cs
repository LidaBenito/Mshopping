namespace Petshop.Endpoint.Controllers;

public class PaymentController : BaseController
{
    private readonly OrderRepository orderRepository;
    private readonly PaymentService paymentService;
    private readonly IConfiguration configuration;
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	public PaymentController(OrderRepository orderRepository, PaymentService paymentService, IConfiguration configuration, IMediator mediator, IMapper mapper)
	{
		this.orderRepository = orderRepository;
		this.paymentService = paymentService;
		this.configuration = configuration;
		_mediator = mediator;
		_mapper = mapper;
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
            var verifyResult = paymentService.Varify(result.Token.ToString());
            if (verifyResult.IsCorrect)
            {
                orderRepository.SetPaymentDone(verifyResult.FactorNumber, verifyResult.TransId);
                verifyResult.Message = "پرداخت با موفقیت انجام شد .";

                return View("PaymentCompelete", verifyResult);
            }
        }

        result.ErrorCode = "404";
        result.ErrorMessage = "پرداخت ناموفق !";
        return View(result);

    }
}
