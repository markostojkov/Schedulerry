using FluentValidation;
using Schedulerry.Domain.Validators;
using Schedulerry.Persistence.AppDbContext;

namespace Schedulerry.Domain.Users.Organizer
{
    public class VerifyInvitedOrganizationAndSetPasswordValidator : AbstractValidator<VerifyInvitedOrganizationAndSetPasswordCommand>
    {
        public VerifyInvitedOrganizationAndSetPasswordValidator(SchedulerryDbContext dbContext)
        {
            RuleFor(x => x.VerificationCode).SetValidator(new OrganizerVerificationCodeValid(dbContext));
        }
    }
}
