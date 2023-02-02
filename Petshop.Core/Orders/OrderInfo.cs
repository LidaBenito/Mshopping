using Petshop.Core.Products;

namespace Petshop.Core.Orders
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int TotalPrice => (Quantity * (Product.Price));
        
    }
}
