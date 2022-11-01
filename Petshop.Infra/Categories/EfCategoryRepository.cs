using Petshop.Contract.Categories;
using Petshop.Core.Categories;
using Petshop.Infra.Common;

namespace Petshop.Infra.Categories
{
    public class EfCategoryRepository : CategoryRepository
    {
        private readonly BentiShopContext dbContext;

        public EfCategoryRepository(BentiShopContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Category> Categories() => dbContext.Categories.ToList();
    }
}
