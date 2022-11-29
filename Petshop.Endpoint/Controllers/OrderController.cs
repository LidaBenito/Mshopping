using Petshop.Contract.Orders;
using Petshop.Core.Orders;

namespace Petshop.Endpoint.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository orderRepository;
        private readonly Basket basket;

        public OrderController(OrderRepository orderRepository, Basket basket)
        {
            this.orderRepository = orderRepository;
            this.basket = basket;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel viewModel)

        {
            if (!basket.Items.Any())
            {
                ModelState.AddModelError("", "کالایی موجود نیست");
            }
            if (ModelState.IsValid)
            {
                Order order = new ()
                {
                    FullName = viewModel.FullName,
                    Address = viewModel.Address,
                    Address2 = viewModel.Address2,
                    City = viewModel.City,
                    Country = viewModel.Country,
                    GiftWrap = viewModel.GiftWrap,
                    Zip = viewModel.Zip,
                    State = viewModel.State

                };
                order.PaymentOrder = new PaymentOrder
                {
                    PaymentDate = DateTime.Today,

                };

                order.Orders = new List<OrderInfo>();
                foreach (var item in basket.Items)
                {
                    order.Orders.Add(new OrderInfo
                    {
                        Products = item.Product,
                        Quantity = item.Quantity
                    });
                }
                orderRepository.SaveOrder(order);
                basket.Clear();
                return RedirectToAction("Compelete");
            }
            return View(viewModel);
        }
        public IActionResult Compelete()
        {
            return View();
        }
    }
}
