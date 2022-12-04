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
                //TempData["price"] = order.Orders.Sum(p => p.Products.Price * p.Quantity);
               orderRepository.SaveOrder(order);
                basket.Clear(); 
                
                return RedirectToAction(nameof(Compelete),new { orderId = order.Id});
            }
            else
            {

            return View(viewModel);
            }
        }
        public IActionResult Compelete(int orderId)
        {
            var order = orderRepository.Find(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        public IActionResult Compelete(Order order)
        {
            return View(order);

        }
    }
}
