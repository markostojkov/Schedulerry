using FluentValidation;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceValidator()
        {
        }
    }
}
