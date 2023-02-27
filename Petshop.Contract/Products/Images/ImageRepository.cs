using Petshop.Core.Products;

namespace Petshop.Contract.Products.Images;

public interface ImageRepository
{
	void  AddImage(Imagee image);
	void DeleteImage(Imagee image);
	Imagee UpdateImage(Imagee image);
	List<Imagee> Images();


}
