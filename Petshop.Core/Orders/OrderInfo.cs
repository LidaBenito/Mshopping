using Petshop.Core.Products;

namespace Petshop.Core.Orders
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public Product Products { get; set; }
        public int Quantity { get; set; }
    }
}
