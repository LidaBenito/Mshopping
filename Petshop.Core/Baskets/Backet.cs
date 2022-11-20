using Petshop.Core.Products;

namespace Petshop.Core.Baskets;

public class Basket
{
    private List<BasketItem> basketItems = new();
    public virtual void AddItem(int quantity, Product product)
    {
        var currentProduct = basketItems.Where(productId => productId.Id == product.Id).FirstOrDefault();
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
    public virtual void RemoveItem(Product product) => basketItems.RemoveAll(productId => productId.Id == product.Id);
    public virtual int TotalPrice() => basketItems.Sum(productItem => productItem.Product.Price * productItem.Quantity);
    public void Clear() => basketItems.Clear();


    public IEnumerable<BasketItem> Items => basketItems;


}
