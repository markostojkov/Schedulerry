using FluentValidation;
using Schedulerry.Domain.Validators;
using Schedulerry.Persistence.AppDbContext;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class AddOrganizerValidator : AbstractValidator<AddOrganizerCommand>
    {
        public AddOrganizerValidator(SchedulerryDbContext dbContext)
        {
            RuleFor(x => x.Username).SetValidator(new ApplicationUserUsernameUnique(dbContext));
            RuleFor(x => x.Email).SetValidator(new ApplicationUserEmailUnique(dbContext));
        }
    }
}
