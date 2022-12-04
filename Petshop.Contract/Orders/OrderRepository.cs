using Petshop.Core.Orders;

namespace Petshop.Contract.Orders
{
    public interface OrderRepository
    {
        

        Order Find(int id);
        void SaveOrder(Order order);
        void SetTransactionId(int id, string token);
    }
}
