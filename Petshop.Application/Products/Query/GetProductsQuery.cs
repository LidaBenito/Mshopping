using Petshop.Core.Products;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Products.Query;

public class GetProductsQuery:IQuery<List<Product>>
{
}
