namespace Petshop.Utility.MediatRHelper;

public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData>
	where TQuery : class, IQuery<TData>
{
	protected virtual Task<TData> ResultAsync(TData data)
	{
		return Task.FromResult(data);
	}
	protected virtual TData Result(TData data)
	{
		return data;
	}

	public abstract Task<TData> Handle(TQuery query, CancellationToken cancellationToken);

}
