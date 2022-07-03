using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Errors;
using Schedulerry.Persistence.AppDbContext;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Validators
{
    public class OrganizationNameIsUnique : AsyncValidatorBase
    {
        public OrganizationNameIsUnique(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            string organizationName = (string)context.PropertyValue;
            return !(await DbContext.Organizations.AnyAsync(x => x.Name == organizationName));
        }

        protected override string GetDefaultMessageTemplate()
        {
            return ErrorCodes.MustBeUnique;
        }
    }
}
