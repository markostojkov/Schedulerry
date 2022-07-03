using MediatR;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Common.Mediator.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Common.Mediator
{
    public class MediatorService : IMediatorService
    {
        private readonly IMediator mediator;

        public MediatorService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken)
        {
            return await mediator.Send(request, cancellationToken);
        }

        public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request)
        {
            return await mediator.Send(request);
        }
    }
}
