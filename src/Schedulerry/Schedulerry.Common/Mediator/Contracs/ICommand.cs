using MediatR;

namespace Schedulerry.Common.Mediator.Contracs
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}
