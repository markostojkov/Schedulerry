using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Errors;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Validators
{
    public class CustomerDoesNotHaveReservationAtDateTime : AsyncValidatorBase
    {
        public CustomerDoesNotHaveReservationAtDateTime(SchedulerryDbContext dbContext, ICurrentUser currentUser)
        {
            DbContext = dbContext;
            CurrentUser = currentUser;
        }

        public SchedulerryDbContext DbContext { get; }
        public ICurrentUser CurrentUser { get; }

        protected async override Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var dto = (CustomerDoesNotHaveReservationAtDateTimeDto)context.PropertyValue;

            var serviceOption = await DbContext.ServiceOptions.FirstOrDefaultAsync(x => x.Uid == dto.ServiceOptionUid);

            var reservationStart = dto.DateTimeOfReservation;
            var reservationEnd = dto.DateTimeOfReservation.AddMinutes((int)serviceOption.ServiceOptionTimeLength);

            var reservationsForCurrentCustomerExistsInThatPeriod = await DbContext.Reservations
                .Where(x => x.Customer.ApplicationUserFk == CurrentUser.Id && reservationStart < x.DateTimeOfReservationEnding && reservationEnd > x.DateTimeOfReservation)
                .AnyAsync();

            return !reservationsForCurrentCustomerExistsInThatPeriod;
        }

        protected override string GetDefaultMessageTemplate()
        {
            return ErrorCodes.CustomerAlreadyHasReservationInThatInterval;
        }
    }
}
