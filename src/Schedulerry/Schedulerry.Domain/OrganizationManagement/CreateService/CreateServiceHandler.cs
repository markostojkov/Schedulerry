using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceHandler : ICommandHandler<CreateServiceCommand, CreateServiceDto>
    {
        public CreateServiceHandler(SchedulerryDbContext dbContext, ICurrentUser currentUser)
        {
            DbContext = dbContext;
            CurrentUser = currentUser;
        }

        public SchedulerryDbContext DbContext { get; }

        public ICurrentUser CurrentUser { get; }

        public async Task<CreateServiceDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service(request.Name, request.Description, request.LogoUrl);
            var databaseOrganization = await DbContext.Organizations.FirstOrDefaultAsync(x => x.Uid == request.OrganizationUid);
            databaseOrganization.Services.Add(service);
            
            await DbContext.SaveChangesAsync();

            return new CreateServiceDto(service.Uid, service.Name, service.Description, service.ImageUrl);
        }
    }
}
