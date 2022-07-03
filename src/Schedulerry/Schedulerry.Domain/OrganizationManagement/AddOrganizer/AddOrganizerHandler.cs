using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class AddOrganizerHandler : ICommandHandler<AddOrganizerCommand, AddOrganizerDto>
    {
        public AddOrganizerHandler(SchedulerryDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        public SchedulerryDbContext DbContext { get; }
        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<AddOrganizerDto> Handle(AddOrganizerCommand request, CancellationToken cancellationToken)
        {
            var organization = await DbContext.Organizations.FirstOrDefaultAsync(x => x.Uid == request.OrganizationUid);

            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                Role = UserRole.Organizer
            };

            await UserManager.CreateAsync(user);

            var organizer = new Organizer(user.Id, organization.Id); 

            DbContext.Organizers.Add(organizer);
            await DbContext.SaveChangesAsync();

            return new AddOrganizerDto(
                organizer.Uid,
                organization.Uid,
                organizer.VerificationCode,
                organization.Name,
                user.Email,
                user.UserName,
                user.EmailConfirmed);
        }
    }
}
