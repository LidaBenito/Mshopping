using Petshop.Core.Orders;
using Petshop.Core.Products;

namespace Petshop.UI.UserDashboard.Models
{
    public class OrderListViewModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zip { get; set; }
        public int GiftWrap { get; set; }
        public Product Product { get; set; }
        public List<OrderInfo> OrdersInfo { get; set; }
        public PaymentOrder PaymentOrder { get; set; }

    }
}
