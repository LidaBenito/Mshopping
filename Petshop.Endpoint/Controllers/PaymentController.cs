using Microsoft.AspNetCore.Mvc.ModelBinding;
using Petshop.Contract.Orders;
using Petshop.Contract.Payments;
using Petshop.Core.Payments;

namespace Petshop.Endpoint.Controllers
{
    public class PaymentController : Controller
    {
        private readonly OrderRepository orderRepository;
        private readonly PaymentService paymentService;
        private readonly IConfiguration configuration;

        public PaymentController(OrderRepository orderRepository, PaymentService paymentService, IConfiguration configuration)
        {
            this.orderRepository = orderRepository;
            this.paymentService = paymentService;
            this.configuration = configuration;
        }
        [HttpPost]
        public IActionResult RequestPayment(int Id)
        {
            var order = orderRepository.GetPaymentOrder(Id);
            var result = paymentService.Request(order.Orders.Sum(p => p.Products.Price).ToString(), "09121234567", order.Id.ToString(), order.Address);
            if (result.IsCorrect)
            {
                orderRepository.SetTransactionId(Id, result.Token,order.PaymentOrder.Id);
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
                    orderRepository.SetPaymentDone(verifyResult.FactorNumber,verifyResult.TransId);
                    verifyResult.Message = "پرداخت با موفقیت انجام شد .";
                
                return View("PaymentCompelete",verifyResult    );
                }
            }

			result.ErrorCode = "404";
			result.ErrorMessage = "پرداخت ناموفق !";
                return View(result);
            
        }
    }
}
