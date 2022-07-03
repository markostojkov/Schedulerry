using FluentValidation.Validators;
using Schedulerry.Common.Errors;
using Schedulerry.Domain.OrganizationManagement;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Validators
{
    public class ServiceOptionScheduleDaysDoNotRepeat : AsyncValidatorBase
    {
        protected override Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var workingDays = (IEnumerable<CreateServiceOptionWorkingTimeCommandDto>)context.PropertyValue;

            return Task.FromResult(workingDays.Count() == workingDays.Select(x => x.DayOfWeek).Distinct().Count());
        }

        protected override string GetDefaultMessageTemplate()
        {
            return ErrorCodes.WorkingDatesRepeat;
        }
    }
}
