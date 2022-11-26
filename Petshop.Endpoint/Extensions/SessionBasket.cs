using Petshop.Core.Products;

public class SessionBasket : Basket
{
    private ISession _session;
    public static SessionBasket GetBasket(IServiceProvider service)
    {
        var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
        SessionBasket basket = session.GetJson<SessionBasket>("Basket")??new SessionBasket();
        basket._session = session;
        return basket;
    }
    public override void AddItem(int quantity, Product product)
    {
        base.AddItem(quantity, product);
        _session.SetJson("Basket", this);
    }
    public override void RemoveItem(Product product)
    {
        base.RemoveItem(product);
        _session.SetJson("Basket", this);
    }
    public override void Clear()
    {
        base.Clear();
        _session.Remove("Basket");
    }

}
