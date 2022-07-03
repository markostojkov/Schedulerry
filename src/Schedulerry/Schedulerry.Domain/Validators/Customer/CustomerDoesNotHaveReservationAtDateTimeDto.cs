using System;

namespace Schedulerry.Domain.Validators
{
    public class CustomerDoesNotHaveReservationAtDateTimeDto
    {
        public CustomerDoesNotHaveReservationAtDateTimeDto(Guid serviceOptionUid, DateTime dateTimeOfReservation)
        {
            ServiceOptionUid = serviceOptionUid;
            DateTimeOfReservation = dateTimeOfReservation;
        }

        public Guid ServiceOptionUid { get; }
        public DateTime DateTimeOfReservation { get; }
    }
}
