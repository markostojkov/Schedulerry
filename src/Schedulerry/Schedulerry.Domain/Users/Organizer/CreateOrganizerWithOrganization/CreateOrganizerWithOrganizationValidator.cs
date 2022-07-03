using FluentValidation;
using Schedulerry.Domain.Validators;
using Schedulerry.Persistence.AppDbContext;

namespace Schedulerry.Domain.Users.Organizer
{
    public class CreateOrganizerWithOrganizationValidator : AbstractValidator<CreateOrganizerWithOrganizationCommand>
    {
        public CreateOrganizerWithOrganizationValidator(SchedulerryDbContext dbContext)
        {
            RuleFor(x => x.OrganizationName).SetValidator(new OrganizationNameIsUnique(dbContext));
            RuleFor(x => x.OrganizerUsername).SetValidator(new ApplicationUserUsernameUnique(dbContext));
            RuleFor(x => x.OrganizerEmail).SetValidator(new ApplicationUserEmailUnique(dbContext));
        }
    }
}
