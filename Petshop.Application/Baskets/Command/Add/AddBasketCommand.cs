using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Baskets.Command.Add
{
	public class AddBasketCommand : ICommand
	{
		public int productId { get; set; }
	}
}
