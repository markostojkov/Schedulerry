using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Users.Organizer
{
    public class VerifyInvitedOrganizationAndSetPasswordHandler : ICommandHandler<VerifyInvitedOrganizationAndSetPasswordCommand, CreatedEntity>
    {
        public VerifyInvitedOrganizationAndSetPasswordHandler(SchedulerryDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        public SchedulerryDbContext DbContext { get; }
        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<CreatedEntity> Handle(VerifyInvitedOrganizationAndSetPasswordCommand request, CancellationToken cancellationToken)
        {
            var organizer = await DbContext.Organizers
                .Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(x => x.VerificationCode == request.VerificationCode);

            organizer.ApplicationUser.EmailConfirmed = true;

            await UserManager.AddPasswordAsync(organizer.ApplicationUser, request.Password);
            await DbContext.SaveChangesAsync();

            return new CreatedEntity(organizer.Id, organizer.Uid);
        }
    }
}
