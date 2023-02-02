using Petshop.Core.Orders;

namespace Petshop.Contract.Orders
{
    public interface OrderRepository
    {

		void Save(Order order);

		Order GetOrder(int id);
        Order GetPaymentOrder(int orderId);
		List<Order> GetUnsendOrders();
        void UpdateOrder(Order order);
		void SetPaymentDone(string factorNumber, string transId);
		void SetTransactionId(int id, string token,int paymentId);
    }
}
