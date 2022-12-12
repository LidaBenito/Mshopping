using Petshop.Core.Orders;

namespace Petshop.Contract.Orders
{
    public interface OrderRepository
    {
        

        Order Get(int id);
        Order GetPaymentOrder(int orderId);
		List<Order> GetUnsendOrders();
        void SaveOrder(Order order);
		void SetPaymentDone(string factorNumber, string transId);
		void SetTransactionId(int id, string token,int paymentId);
    }
}
