using FluentValidation;
using Schedulerry.Domain.Validators;
using Schedulerry.Persistence.AppDbContext;

namespace Schedulerry.Domain.Users.Customer.VerifyCustomer
{
    public class VerifyCustomerValidator : AbstractValidator<VerifyCustomerCommand>
    {
        public VerifyCustomerValidator(SchedulerryDbContext dbContext)
        {
            RuleFor(x => x.VerificationCode).SetValidator(new CustomerVerificationCodeValid(dbContext));
        }
    }
}
