using Petshop.Core.Baskets;

namespace Petshop.Endpoint.Models.Baskets;

public class BasketViewModel
{
    public Basket Basket{ get; set; }
    public string returnURL{ get; set; }
}
