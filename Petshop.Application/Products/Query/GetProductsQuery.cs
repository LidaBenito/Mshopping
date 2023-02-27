using Petshop.Core.Products;
using Petshop.Utility.MediatRHelper;
using Petshop.Utility.Paginations;

namespace Petshop.Application.Products.Query;

public class GetProductsQuery:IQuery<PagedData<Product>>
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public string Search { get; set; } = "";
}
