using Petshop.Core.Categories;

namespace Petshop.UI.UserDashboard.Models.Products;

public class AddProductViewModel
{
	
	public string Name { get; set; }
	public string Description { get; set; }
	public IFormFile Image { get; set; }
	public int Price { get; set; }
	public int CategoryId { get; set; }
	public List<Category> CategoryForDisplay { get; set; }
}
