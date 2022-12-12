using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Petshop.Contract.Orders;
using Petshop.Core.Orders;
using Petshop.Infra.Common;

namespace Petshop.Infra.Orders;

public class EFOrderRepository : OrderRepository
{
    private readonly BentiShopContext dbContext;

    public EFOrderRepository(BentiShopContext dbContext)
    {
        this.dbContext = dbContext;
    }



    public Order Get(int id) => dbContext.Orders.Include(c => c.Orders).ThenInclude(p => p.Products).FirstOrDefault(order => order.Id == id);

    public Order GetPaymentOrder(int orderId) => dbContext.Orders.Include(z=>z.PaymentOrder).Include(c => c.Orders).ThenInclude(p => p.Products).FirstOrDefault(order => order.Id == orderId);

	public List<Order> GetUnsendOrders()=>dbContext.Orders.Include(payment=>payment.PaymentOrder.Shipped==false).ToList();
	

	public void SaveOrder(Order order)
    {
        dbContext.AttachRange(order.Orders.Select(products => products.Products));
        dbContext.Orders.Add(order);
        dbContext.SaveChanges();
    }

		public void SetPaymentDone(string FactorNumber,string TransId)
		{
        var order = dbContext.Orders.Include(z => z.PaymentOrder).FirstOrDefault(o=>o.Id==int.Parse(FactorNumber));
        var payment = dbContext.Orders.SingleOrDefault(c => c.PaymentOrder.Id == order.PaymentOrder.Id);
            ;
			if (order != null)
			{

            payment.PaymentOrder.PaymentCode = TransId;
            payment.PaymentOrder.PaymentDate = DateTime.Now;
                

				dbContext.SaveChanges();
			}
		}

	

	void OrderRepository.SetTransactionId(int id, string token,int paymentId)
    {
        var order = dbContext.Orders.FirstOrDefault(order=>order.Id==id && order.PaymentOrder.Id==paymentId);
        if (order != null)
        {
            order.PaymentOrder.PaymentCode = token;
            order.PaymentOrder.PaymentDate = DateTime.Now;
            
            
            dbContext.SaveChanges();
        }
    }
}
