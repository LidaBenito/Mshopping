using Petshop.Contract.Products;
using Petshop.Core.Baskets;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Application.Baskets.Command.Remove;

class RemoveBasketHandler : CommandHandler<RemoveBasketCommand>
{
	private readonly ProductRepository productRepository;
	private readonly Basket sessionBasket;
	public RemoveBasketHandler(ProductRepository productRepository, Basket sessionBasket)
	{
		this.productRepository = productRepository;
		this.sessionBasket = sessionBasket;
	}

	public override Task<Result> Handle(RemoveBasketCommand command, CancellationToken cancellationToken)
	{
		if(command is not null)
		{
			var products = productRepository.GetProduct(command.productId);
			sessionBasket.RemoveItem(products);
		}
		return OkAsync();
	}
}
