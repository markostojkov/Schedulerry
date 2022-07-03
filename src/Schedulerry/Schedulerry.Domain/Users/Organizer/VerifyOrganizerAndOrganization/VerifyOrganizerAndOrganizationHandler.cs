using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Persistence.AppDbContext;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Users.Organizer
{
    public class VerifyOrganizerAndOrganizationHandler : ICommandHandler<VerifyOrganizerAndOrganizationCommand, CreatedEntity>
    {
        public VerifyOrganizerAndOrganizationHandler(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }

        public async Task<CreatedEntity> Handle(VerifyOrganizerAndOrganizationCommand request, CancellationToken cancellationToken)
        {
            var databaseOrganizer = await DbContext.Organizers
                .Include(x => x.ApplicationUser)
                .Include(x => x.Organization)
                .SingleOrDefaultAsync(x => x.VerificationCode == request.VerificationCode);

            databaseOrganizer.ApplicationUser.EmailConfirmed = true;
            databaseOrganizer.Organization.IsVerified = true;

            await DbContext.SaveChangesAsync();

            return new CreatedEntity(databaseOrganizer.Id, databaseOrganizer.Uid);
        }
    }
}
