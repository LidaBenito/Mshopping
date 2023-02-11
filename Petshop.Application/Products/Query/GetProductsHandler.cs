using Petshop.Contract.Products;
using Petshop.Core.Products;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Products.Query;

class GetProductsHandler : QueryHandler<GetProductsQuery, List<Product>>
{
	private readonly ProductRepository productRepository;
	public GetProductsHandler(ProductRepository productRepository)
	{
		this.productRepository = productRepository;
	}
	public override Task<List<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
	{
		var products=productRepository.GetProducts();
		return ResultAsync(products);
	}
}
