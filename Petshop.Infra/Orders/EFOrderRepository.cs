using Microsoft.EntityFrameworkCore;
using Petshop.Contract.Orders;
using Petshop.Core.Orders;
using Petshop.Infra.Common;

namespace Petshop.Infra.Orders
{
    public class EFOrderRepository : OrderRepository
    {
        private readonly BentiShopContext dbContext;

        public EFOrderRepository(BentiShopContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public Order Find(int id) => dbContext.Orders.Include(c => c.Orders).ThenInclude(p => p.Products).FirstOrDefault(order => order.Id == id);
        public void SaveOrder(Order order)
        {
            dbContext.AttachRange(order.Orders.Select(products => products.Products));
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        void OrderRepository.SetTransactionId(int id, string token)
        {
            var order = dbContext.Orders.Find(id);
            if (order != null)
            {

                order.PaymentOrder = new PaymentOrder()
                {
                    PaymentCode = token,
                    Shipped = true,
                    PaymentDate = DateTime.Now
                };
                
                dbContext.SaveChanges();
            }
        }
    }
}
