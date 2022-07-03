using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Errors;
using Schedulerry.Persistence.AppDbContext;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Validators
{
    public class ApplicationUserUsernameUnique : AsyncValidatorBase
    {
        public ApplicationUserUsernameUnique(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            string username = (string)context.PropertyValue;
            return !(await DbContext.Users.AnyAsync(x => x.UserName == username));
        }

        protected override string GetDefaultMessageTemplate()
        {
            return ErrorCodes.MustBeUnique;
        }
    }
}
