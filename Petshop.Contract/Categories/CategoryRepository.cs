using Petshop.Core.Categories;

namespace Petshop.Contract.Categories
{
    public interface CategoryRepository
    {
        List<Category> GetAllCategories();


    }
}
