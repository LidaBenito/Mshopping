using Petshop.Contract.Categories;
using Petshop.Contract.Products;
using Petshop.Core.Products;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Application.Products.Command.Add;

class AddProductHandler : CommandHandler<AddProductCommand>
{
	private readonly CategoryRepository categoryRepository;
	private readonly ProductRepository  productRepository;

	public AddProductHandler(CategoryRepository categoryRepository, ProductRepository productRepository)
	{
		this.categoryRepository = categoryRepository;
		this.productRepository = productRepository;
	}
	public override Task<Result> Handle(AddProductCommand command, CancellationToken cancellationToken)
	{
		Product product = new()
		{
			CategoryId = command.CategoryId,
			Description = command.Description,
			Name = command.Name,
			Price = command.Price,
			Category = categoryRepository.GetCategory(command.CategoryId)
		};
		AddProductsImage(command, product);
		productRepository.AddProduct(product);
		return OkAsync();
	}

	private static void AddProductsImage(AddProductCommand command, Product product)
	{
		if (command?.Image?.Length > 0)
		{
			using (var ms = new MemoryStream())
			{

				command.Image.CopyTo(ms);
				var fileBytes = ms.ToArray();
				product.Image = Convert.ToBase64String(fileBytes);
			}
		}
	}
}
