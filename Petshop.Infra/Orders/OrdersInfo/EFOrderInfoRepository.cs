using Microsoft.EntityFrameworkCore;
using Petshop.Contract.Orders.OrdersInfo;
using Petshop.Core.Orders;
using Petshop.Infra.Common;

namespace Petshop.Infra.Orders.OrdersInfo;

public class EFOrderInfoRepository : OrderInfoRepository
{
    private readonly BentiShopContext dbContext;

    public EFOrderInfoRepository(BentiShopContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public List<OrderInfo> GetOrderInfos() => dbContext.OrderInfos.Include(x=>x.Product).ToList();
}


