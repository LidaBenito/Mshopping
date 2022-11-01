using Petshop.Core.Products;

namespace Petshop.Core.Categories
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product>   Products{ get; set; }

    }
}
