using Petshop.Core.Orders;

namespace Petshop.Contract.Orders
{
    public interface OrderRepository
    {
        void SaveOrder(Order order);
    }
}
