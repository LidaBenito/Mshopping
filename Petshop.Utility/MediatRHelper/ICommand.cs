using MediatR;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Utility.MediatRHelper;

public interface ICommand : IRequest<Result>
{
}
public interface ICommand<T> : IRequest<Result<T>>
{
}
