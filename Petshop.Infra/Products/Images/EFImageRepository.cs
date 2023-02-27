using Petshop.Contract.Products.Images;
using Petshop.Core.Products;
using Petshop.Infra.Common;

namespace Petshop.Infra.Products.Images;

public class EFImageRepository : ImageRepository
{
	private readonly BentiShopContext dbContext;
	public EFImageRepository(BentiShopContext dbContext)
	{
		this.dbContext = dbContext;
	}
	public void AddImage(Imagee image)
	{
		dbContext.Imagees.Add(image);
		dbContext.SaveChanges();
	}

	public void DeleteImage(Imagee image)
	{
		throw new NotImplementedException();
	}

	public List<Imagee> Images()
	{
		throw new NotImplementedException();
	}

	public Imagee UpdateImage(Imagee image)
	{
		throw new NotImplementedException();
	}
}
