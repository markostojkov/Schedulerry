using Microsoft.AspNetCore.Identity;
using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Users.Organizer
{
    public class CreateOrganizerWithOrganizationHandler : ICommandHandler<CreateOrganizerWithOrganizationCommand, CreatedEntity>
    {
        public CreateOrganizerWithOrganizationHandler(SchedulerryDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        public SchedulerryDbContext DbContext { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<CreatedEntity> Handle(CreateOrganizerWithOrganizationCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.OrganizerUsername,
                Email = request.OrganizerEmail,
                Role = UserRole.Organizer
            };
            await UserManager.CreateAsync(user, request.OrganizerPassword);

            var organization = new Organization(request.OrganizationName);
            var organizer = new Persistence.Entities.Organizer(user.Id, organization.Id);
            organization.Organizers.Add(organizer);
            DbContext.Organizations.Add(organization);

            await DbContext.SaveChangesAsync();

            return new CreatedEntity(organizer.Id, organizer.Uid, organizer.VerificationCode);
        }
    }
}
