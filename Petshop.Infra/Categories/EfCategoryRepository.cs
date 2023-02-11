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
        public List<Category> GetAllCategories() => dbContext.Categories.ToList();

		public Category GetCategory(int id)
		{
            var category=dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            return category;
		}
	}
}
