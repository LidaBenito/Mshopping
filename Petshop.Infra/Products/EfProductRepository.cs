using Microsoft.EntityFrameworkCore;
using Petshop.Contract.Products;
using Petshop.Core.Categories;
using Petshop.Core.Products;
using Petshop.Infra.Common;
using Petshop.Utility.Paginations;

namespace Petshop.Infra.Products
{
    public class EfProductRepository : ProductRepository
    {
        private readonly BentiShopContext dbContext;

        public EfProductRepository(BentiShopContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<string> GetAllCategories() => dbContext.Products.Select(product => product.Category.Name).Distinct().ToList();


        public PagedData<Product> GetAllProducts(int pageNumber, int pageSize,string category) {
            var result = new PagedData<Product>
            {
                PageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                }
            };
            result.Data= dbContext.Products.Include(product => product.Category).Where(c=> string.IsNullOrWhiteSpace(category)
            || c.Category.Name == category).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount = dbContext.Products.Where(c => string.IsNullOrWhiteSpace(category)
            || c.Category.Name == category).Count();

            return result;
        }
        
    }
}
