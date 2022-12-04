using Petshop.Contract.Orders;
using Petshop.Contract.Payments;
using Petshop.Core.Payments;

namespace Petshop.Endpoint.Controllers
{
    public class PaymentController : Controller
    {
        private readonly OrderRepository orderRepository;
        private readonly PaymentRepository paymentRepository;
        private readonly IConfiguration configuration;

        public PaymentController(OrderRepository orderRepository, PaymentRepository paymentRepository, IConfiguration configuration)
        {
            this.orderRepository = orderRepository;
            this.paymentRepository = paymentRepository;
            this.configuration = configuration;
        }
        [HttpPost]
        public IActionResult RequestPayment(int Id)
        {
            var order = orderRepository.Find(Id);
            var result = paymentRepository.Request(order.Orders.Sum(p => p.Products.Price).ToString(), "09121234567", order.Id.ToString(), order.Address);
            if (result.IsCorrect)
            {
                orderRepository.SetTransactionId(Id, result.Token);
                return Redirect($"{configuration["payIr:PaymentUrl"]}{result.Token}");
            }
            return View(result);
        
        }
        public IActionResult Verify(RequestPaymentResult model)
        {
            if (model.IsCorrect)
            {

            }
            return View(model);
        }
    }
}
