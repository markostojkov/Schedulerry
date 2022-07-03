using FluentValidation;
using Schedulerry.Domain.Validators;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceOptionWorkingTimeValidator : AbstractValidator<CreateServiceOptionWorkingTimeCommand>
    {
        public CreateServiceOptionWorkingTimeValidator()
        {
            RuleFor(x => x.ServiceOptionWorkingTimes).SetValidator(new ServiceOptionScheduleDaysDoNotRepeat());
        }
    }
}
