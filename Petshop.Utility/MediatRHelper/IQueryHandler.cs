using MediatR;

namespace Petshop.Utility.MediatRHelper;

public interface IQueryHandler<TInput, TOutput> : IRequestHandler<TInput, TOutput>
    where TInput : IQuery<TOutput>
{
}
