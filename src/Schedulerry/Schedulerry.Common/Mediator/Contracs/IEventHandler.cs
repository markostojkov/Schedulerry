using MediatR;

namespace Schedulerry.Common.Mediator.Contracs
{
    public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent
    {
    }
}
