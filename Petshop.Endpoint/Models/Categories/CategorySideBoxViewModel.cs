using Petshop.Core.Categories;

namespace Petshop.Endpoint.Models.Categories
{
    public class CategorySideBoxViewModel
    {
        public List<Category> categories{ get; set; }
        public string currentCategory { get; set; }

    }
}
