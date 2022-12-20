using Petshop.Contract.Orders.OrdersInfo;
using Petshop.Contract.Orders.Services;
using Petshop.Core.Products;

namespace Petshop.Application.OrdersService
{
    public class EFOrderInfoService : OrderInfoService
    {
        private readonly OrderInfoRepository orderInfoRepository;

        public EFOrderInfoService(OrderInfoRepository orderInfoRepository)
        {
            this.orderInfoRepository = orderInfoRepository;
        }

        public List<Product> GetProductsByOrders()
        {
            var ordersInfo = orderInfoRepository.GetOrderInfos();
            List<Product> currentProducts = new();
            foreach (var item in ordersInfo)
            {
                if (!currentProducts.Contains(item.Product))
                {
                    currentProducts.Add(item.Product);

                }
            }
            return currentProducts;
        }
    }
}
