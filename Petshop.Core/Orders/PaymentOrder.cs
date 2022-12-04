namespace Petshop.Core.Orders
{
    public class PaymentOrder
    {
        public int Id{ get; set; }
        public string? PaymentCode{ get; set; }
        public DateTime? PaymentDate{ get; set; }
        public bool Shipped{ get; set; }
    }
}
