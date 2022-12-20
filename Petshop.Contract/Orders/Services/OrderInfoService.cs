using Petshop.Core.Products;

namespace Petshop.Contract.Orders.Services
{
    public interface OrderInfoService
    {
        List<Product> GetProductsByOrders();
    }
}
