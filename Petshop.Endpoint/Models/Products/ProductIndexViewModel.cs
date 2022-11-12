using Petshop.Core.Products;
using Petshop.Utility.Paginations;

namespace Petshop.Endpoint.Models.Products
{
    public class ProductIndexViewModel
    {
        public PagedData<Product> Data { get; set; }
        public string Search{ get; set; }
    }
}
