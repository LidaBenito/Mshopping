using Petshop.Core.Orders;
using System.ComponentModel.DataAnnotations;

namespace Petshop.Endpoint.Models.Orders
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage ="لطفا نام را وارد کنبد!")]
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public int GiftWrap { get; set; }
        public List<OrderInfo> Orders { get; set; }
        public PaymentOrder PaymentOrder { get; set; }
    }
}
