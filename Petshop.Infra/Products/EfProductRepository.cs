using Microsoft.EntityFrameworkCore;
using Petshop.Contract.Products;
using Petshop.Core.Products;
using Petshop.Infra.Common;
using Petshop.Utility.Paginations;
using System.Text;

namespace Petshop.Infra.Products;

public class EfProductRepository : ProductRepository
{
    private readonly BentiShopContext dbContext;

    public EfProductRepository(BentiShopContext dbContext)
    {
        this.dbContext = dbContext;
    }

		public void AddProduct(Product product)
		{
        dbContext.Products.Add(product);
        dbContext.SaveChanges();
		}

		public PagedData<Product> GetProducts(PageInfo pageInfo,string category) {

        PagedData<Product> result= new();
		result.Data = dbContext.Products.Include(s => s.Imagee).Include(product => product.Category).Where(c => string.IsNullOrWhiteSpace(category)
        || c.Category.Name == category).Skip((pageInfo.PageNumber - 1) * pageInfo.PageSize).Take(pageInfo.PageSize).ToList();
       
		result.PageInfo = new();
		result.PageInfo.TotalCount= dbContext.Products.Count();


	

		return result;
    }

    public Product GetProduct(int productId) => dbContext.Products.FirstOrDefault(productid => productid.Id == productId);

    public List<Product> GetProducts() => dbContext.Products.Include(c=>c.Category).OrderBy(o=>o.CategoryId).Include(z=>z.Imagee).ToList();
}
