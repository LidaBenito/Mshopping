using Petshop.Core.Products;
using Petshop.Utility.Paginations;

namespace Petshop.Contract.Products;

public interface ProductRepository
{
    PagedData<Product> GetProducts(PageInfo pageInfo,string category);
    Product GetProduct(int productId);
    List<Product> GetProducts();
    void AddProduct(Product product);

}
