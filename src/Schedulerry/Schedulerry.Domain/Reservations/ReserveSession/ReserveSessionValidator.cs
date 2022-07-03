using FluentValidation;
using Schedulerry.Common.User;
using Schedulerry.Domain.Validators;
using Schedulerry.Persistence.AppDbContext;

namespace Schedulerry.Domain.Reservations
{
    public class ReserveSessionValidator : AbstractValidator<ReserveSessionCommand>
    {
        public ReserveSessionValidator(SchedulerryDbContext dbContext, ICurrentUser currentUser)
        {
            RuleFor(x => new CustomerDoesNotHaveReservationAtDateTimeDto(x.ServiceOptionUid, x.DateOfReservation)).SetValidator(new CustomerDoesNotHaveReservationAtDateTime(dbContext, currentUser));
            RuleFor(x => new ReservationTimeForServiceOptionValidDto(x.ServiceOptionUid, x.DateOfReservation)).SetValidator(new ReservationTimeForServiceOptionValid(dbContext, currentUser));
        }
    }
}
