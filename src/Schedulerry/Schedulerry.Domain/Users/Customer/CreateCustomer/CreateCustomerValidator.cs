using FluentValidation;
using Schedulerry.Domain.Validators;
using Schedulerry.Persistence.AppDbContext;

namespace Schedulerry.Domain.Users.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator(SchedulerryDbContext dbContext)
        {
            RuleFor(x => x.CustomerUsername).SetValidator(new ApplicationUserUsernameUnique(dbContext));
            RuleFor(x => x.CustomerEmail).SetValidator(new ApplicationUserEmailUnique(dbContext));
        }
    }
}
