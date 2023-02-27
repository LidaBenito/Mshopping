using Petshop.Application.Products.Command.Add;
using Petshop.UI.UserDashboard.Models.Products;

namespace Petshop.UI.UserDashboard.Helpers.MapperProfiles.Products
{
	public class ProductProfile:Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductViewModel, AddProductCommand>();
		}
	}
}
