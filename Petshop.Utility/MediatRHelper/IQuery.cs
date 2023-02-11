using MediatR;

namespace Petshop.Utility.MediatRHelper;

public interface IQuery<T> : IRequest<T>
{
}
