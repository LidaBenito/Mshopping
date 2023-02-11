using Microsoft.AspNetCore.Http;
using Petshop.Core.Products;

namespace Petshop.Core.Baskets;

public class Basket
{
    private List<BasketItem> basketItems = new();
    public virtual void AddItem(int quantity, Product product)
    {
        var currentProduct = basketItems.Where(productId => productId.Product.Id == product.Id).FirstOrDefault();
        if (currentProduct is null)
        {
            basketItems.Add(new BasketItem
            {
                Product = product,
                Quantity = quantity
            });
        }
        else
        {
            currentProduct.Quantity += quantity;
        }
    }
    public virtual void RemoveItem(Product product)
    {
        var result = basketItems.RemoveAll(c => c.Product.Id == product.Id);
      
    }


    public int TotalPrice() => basketItems.Sum(productItem => productItem.Product.Price * productItem.Quantity);
    public virtual void Clear() => basketItems.Clear();


    public IEnumerable<BasketItem> Items => basketItems;


}
