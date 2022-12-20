using Petshop.Core.Products;

namespace Petshop.Core.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string?  Address2{ get; set; }
        public string?  City{ get; set; }
        public string?  State{ get; set; }
        public string?  Country{ get; set; }
        public string?  Zip{ get; set; }
        public int GiftWrap{ get; set; }
        public List<OrderInfo> OrdersInfo { get; set; }
        public PaymentOrder PaymentOrder { get; set; }

    }
}
