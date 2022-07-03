using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Errors;
using Schedulerry.Persistence.AppDbContext;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Validators
{
    public class ApplicationUserEmailUnique : AsyncValidatorBase
    {
        public ApplicationUserEmailUnique(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            string email = (string)context.PropertyValue;
            return !(await DbContext.Users.AnyAsync(x => x.Email == email));
        }

        protected override string GetDefaultMessageTemplate()
        {
            return ErrorCodes.MustBeUnique;
        }
    }
}
