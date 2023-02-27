using Microsoft.AspNetCore.Http;
using Petshop.Core.Categories;
using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Products.Command.Add;

public class AddProductCommand:ICommand
{
	public string Name { get; set; }
	public string Description { get; set; }
	public IFormFile Image { get; set; }
	//public static readonly List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
	public int Price { get; set; }
	public int CategoryId { get; set; }
	public List<Category> CategoryForDisplay { get; set; }
}
