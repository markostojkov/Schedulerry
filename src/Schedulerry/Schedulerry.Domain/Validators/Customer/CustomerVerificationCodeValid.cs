using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Errors;
using Schedulerry.Persistence.AppDbContext;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Validators
{
    public class CustomerVerificationCodeValid : AsyncValidatorBase
    {
        public CustomerVerificationCodeValid(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
            VerificationCodeDateInvalid = false;
        }

        public SchedulerryDbContext DbContext { get; }

        private bool VerificationCodeDateInvalid { get; set; }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var verificationCode = (Guid)context.PropertyValue;

            var databaseCustomer = await DbContext.Customers.SingleOrDefaultAsync(x => x.VerificationCode == verificationCode);

            if (databaseCustomer != null)
            {
                if (databaseCustomer.VerificationCodeExpiration.CompareTo(DateTime.UtcNow) > 0)
                {
                    VerificationCodeDateInvalid = true;
                    return false;
                }
            }

            return databaseCustomer != null;
        }

        protected override string GetDefaultMessageTemplate()
        {
            if (VerificationCodeDateInvalid)
            {
                return ErrorCodes.CodeDatePassed;
            }

            return ErrorCodes.NotFound;
        }
    }
}
