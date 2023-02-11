using AutoMapper;
using Petshop.Application.Baskets.Command.Add;

namespace Petshop.Endpoint.Helpers.MapProfiles.Baskets
{
	public class BasketProfile:Profile
	{
		public BasketProfile()
		{
			CreateMap<AddBasketViewModel, AddBasketCommand>();

		}
	}
}
