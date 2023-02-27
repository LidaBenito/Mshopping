using Petshop.Contract.Categories;
using Petshop.Contract.Products;
using Petshop.Contract.Products.Images;
using Petshop.Core.Products;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Application.Products.Command.Add;

class AddProductHandler : CommandHandler<AddProductCommand>
{
	private readonly CategoryRepository categoryRepository;
	private readonly ProductRepository productRepository;
	private readonly ImageRepository imageRepository;


	public AddProductHandler(CategoryRepository categoryRepository, ProductRepository productRepository, ImageRepository imageRepository)
	{
		this.categoryRepository = categoryRepository;
		this.productRepository = productRepository;
		this.imageRepository = imageRepository;
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
		productRepository.AddProduct(product);
		Imagee image = AddProductsImage(command, product).GetAwaiter().GetResult();
		imageRepository.AddImage(image);
		return OkAsync();
	}

	private async static Task<Imagee> AddProductsImage(AddProductCommand command, Product product)
	{
		Imagee image = new();
		if (command?.Image?.Length > 0)
		{


			using var dataStream = new MemoryStream();
			await command.Image.CopyToAsync(dataStream);
			byte[] imageBytes = dataStream.ToArray();
			string base64String = Convert.ToBase64String(imageBytes);
			image.Img = base64String;
		}
		image.ProductId = product.Id;

		return image;
	}
}