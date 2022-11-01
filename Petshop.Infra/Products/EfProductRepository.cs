using Microsoft.EntityFrameworkCore;
using Petshop.Contract.Products;
using Petshop.Core.Products;
using Petshop.Infra.Common;

namespace Petshop.Infra.Products
{
    public class EfProductRepository : ProductRepository
    {
        private readonly BentiShopContext dbContext;

        public EfProductRepository(BentiShopContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Product> Products() => dbContext.Products.Include(product => product.Category).ToList();
    }
}
