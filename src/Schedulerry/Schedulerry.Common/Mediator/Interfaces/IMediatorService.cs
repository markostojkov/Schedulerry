using Schedulerry.Common.Mediator.Contracs;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Common.Mediator.Interfaces
{
    public interface IMediatorService
    {
        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken);

        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request);
    }
}
