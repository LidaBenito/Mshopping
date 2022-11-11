using Petshop.Core.Products;
using Petshop.Utility.Paginations;

namespace Petshop.Contract.Products
{
    public interface ProductRepository
    {
        PagedData<Product> Products(int pageNumber,int pageSize);


    }
}
