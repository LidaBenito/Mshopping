using MediatR;
using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Utility.MediatRHelper;

public interface ICommandHandler<TInput, TOutput> : IRequestHandler<TInput, Result<TOutput>>
where TInput : ICommand<TOutput>
{
}
public interface ICommandHandler<TInput> : IRequestHandler<TInput, Result>
  where TInput : ICommand
{
}
