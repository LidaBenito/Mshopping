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
        public void SaveOrder(Order order)
        {
            dbContext.AttachRange(order.Orders.Select(products => products.Products));
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }
    }
}
