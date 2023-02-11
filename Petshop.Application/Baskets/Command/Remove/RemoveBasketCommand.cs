using Petshop.Utility.MediatRHelper;

namespace Petshop.Application.Baskets.Command.Remove;

public class RemoveBasketCommand:ICommand
{
	public int productId { get; set; }
}
