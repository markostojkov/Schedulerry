using MediatR;

namespace Schedulerry.Common.Mediator.Contracs
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}
