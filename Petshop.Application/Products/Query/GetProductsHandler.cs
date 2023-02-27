using Petshop.Contract.Products;
using Petshop.Core.Products;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.MediatRHelper.Results;
using Petshop.Utility.Paginations;
using System.Text;

namespace Petshop.Application.Products.Query;

class GetProductsHandler : QueryHandler<GetProductsQuery, PagedData<Product>>
{
	private readonly ProductRepository productRepository;
	
	public GetProductsHandler(ProductRepository productRepository)
	{
		this.productRepository = productRepository;
	}

	public override Task<PagedData<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
	{
		PageInfo pageInfo = new()
		{
			PageNumber = query.PageNumber,
			PageSize = query.PageSize,

		};


		var products = productRepository.GetProducts(pageInfo, query.Search);
		//foreach (var item in products.Data)
		//{
		//	if (item.Imagee != null)
		//	{

		//		string? img = "";
		//		img = item.Imagee.Img;
		//		//byte[] bytes = (byte[])img.Rows
		//		byte[] bytes = Encoding.ASCII.GetBytes(img);
		//		//string imgString = Convert.ToBase64String(bytes);
		//		MemoryStream ms = new MemoryStream(bytes);
		//		item.Imagee.Img= String.Format("data:image/jpeg;base64,{0}", ms);

		//	}
		//}

		return ResultAsync(products);
	}
}
