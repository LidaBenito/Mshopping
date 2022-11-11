using Microsoft.EntityFrameworkCore;
using Petshop.Contract.Products;
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
        public PagedData<Product> Products(int pageNumber, int pageSize) {
            var result = new PagedData<Product>
            {
                PageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                }
            };
            result.Data= dbContext.Products.Include(product => product.Category).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount = dbContext.Products.Count();

            return result;
        }
        
    }
}
