namespace Petshop.Core.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public List<OrderInfo> Orders { get; set; }
    }
}
