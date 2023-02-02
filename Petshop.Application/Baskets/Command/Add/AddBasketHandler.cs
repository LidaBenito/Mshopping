using Petshop.Contract.Products;
using Petshop.Core.Baskets;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Application.Baskets.Command.Add;

public class AddBasketHandler : CommandHandler<AddBasketCommand>
{
	private readonly ProductRepository productRepository;
	private readonly Basket sessionBasket;

	public AddBasketHandler(ProductRepository productRepository, Basket sessionBasket)
	{
		this.productRepository = productRepository;
		this.sessionBasket = sessionBasket;
	}



	public override Task<Result> Handle(AddBasketCommand command, CancellationToken cancellationToken)
	{
		if (command != null)
		{
			var product = productRepository.GetProduct(command.productId);
			sessionBasket.AddItem(1, product);

		}
		return OkAsync();
	}
}