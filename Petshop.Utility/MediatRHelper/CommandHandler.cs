using Petshop.Utility.MediatRHelper.Results;

namespace Petshop.Utility.MediatRHelper
{
	public abstract class CommandHandler<TCommand, TData> : ICommandHandler<TCommand, TData>
		where TCommand : ICommand<TData>
	{
		protected virtual Task<Result<TData>> OkAsyc(TData data)
		{
			return Task.FromResult(Result.Ok(data));
		}
		protected virtual Result<TData> Ok(TData data)
		{
			return Result.Ok(data);
		}

		protected virtual Task<Result<TData>> FailAsync(TData data, string message)
		{
			return Task.FromResult(Result.Fail<TData>(message));

		}
		protected virtual Result<TData> Fail(TData data, string message)
		{
			return Result.Fail<TData>(message);
		}

		public abstract Task<Result<TData>> Handle(TCommand command, CancellationToken cancellationToken);

	}
	public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
	where TCommand : ICommand
	{


		protected virtual Task<Result> OkAsync()
		{
			return Task.FromResult(Result.Ok());
		}
		protected virtual Result Ok()
		{
			return Result.Ok();
		}

		protected virtual Task<Result> FailAsync(string message)
		{
			return Task.FromResult(Result.Fail(message));
		}

		protected virtual Result Fail(string message)
		{
			return Result.Fail(message);
		}


		public abstract Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
	}

}
