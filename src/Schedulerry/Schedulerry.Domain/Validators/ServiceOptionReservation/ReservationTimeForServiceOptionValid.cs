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
    public class ReservationTimeForServiceOptionValid : AsyncValidatorBase
    {
        public ReservationTimeForServiceOptionValid(SchedulerryDbContext dbContext, ICurrentUser currentUser)
        {
            DbContext = dbContext;
            CurrentUser = currentUser;
            ServiceOptionWorkingTimeValid = true;
        }

        public SchedulerryDbContext DbContext { get; }
        public ICurrentUser CurrentUser { get; }
        public bool ServiceOptionWorkingTimeValid { get; private set; }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var dto = (ReservationTimeForServiceOptionValidDto)context.PropertyValue;

            var serviceOption = await DbContext.ServiceOptions
                .Include(x => x.ServiceOptionSchedules)
                .FirstOrDefaultAsync(x => x.Uid == dto.ServiceOptionUid);

            var dayOfWeekSchedule = serviceOption.ServiceOptionSchedules.Find(x => (int)x.DayOfWeek == (int)dto.DateTimeOfReservation.DayOfWeek);

            var reservationStart = dto.DateTimeOfReservation;
            var reservationEnd = dto.DateTimeOfReservation.AddMinutes((int)serviceOption.ServiceOptionTimeLength);

            if (dayOfWeekSchedule.WorkingTimeMinutes == 0)
            {
                ServiceOptionWorkingTimeValid = false;
                return false;
            }

            if (dayOfWeekSchedule.TimeOpen.TimeOfDay > reservationStart.TimeOfDay || dayOfWeekSchedule.TimeOpen.AddMinutes(dayOfWeekSchedule.WorkingTimeMinutes).TimeOfDay < reservationEnd.TimeOfDay)
            {
                ServiceOptionWorkingTimeValid = false;
                return false;
            }

            var reservationsForServiceOptionExistInThatPeriod = await DbContext.Reservations
                .Where(x => x.ServiceOptionFk == serviceOption.Id && reservationStart < x.DateTimeOfReservationEnding && reservationEnd > x.DateTimeOfReservation)
                .AnyAsync();

            return !reservationsForServiceOptionExistInThatPeriod;
        }

        protected override string GetDefaultMessageTemplate()
        {
            if (!ServiceOptionWorkingTimeValid)
            {
                return ErrorCodes.ServiceOptionNotWorkingThatDay;
            }

            return ErrorCodes.ReservationInThatIntervalInvalid;
        }
    }
}
