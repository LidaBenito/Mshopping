using System.ComponentModel.DataAnnotations;

namespace Petshop.Endpoint.Models.Orders;

public class CheckoutViewModel
{
    [Required(ErrorMessage = "لطفا نام را وارد کنید!")]
    public string FullName { get; set; }
    [Required(ErrorMessage = "لطفا آدرس را وارد کنید!")]

    public string Address { get; set; }
    public string Address2 { get; set; }
    [Required(ErrorMessage = "لطفا شهر را وارد کنید!")]

    public string City { get; set; }
    [Required(ErrorMessage = "لطفا استان را وارد کنید!")]

    public string State { get; set; }
    [Required(ErrorMessage = "لطفا کشور را وارد کنید!")]

    public string Country { get; set; }
    public string Zip { get; set; }
    public int GiftWrap { get; set; }

}
