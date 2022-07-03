using System;

namespace Schedulerry.Domain.Validators
{
    public class ReservationTimeForServiceOptionValidDto
    {
        public ReservationTimeForServiceOptionValidDto(Guid serviceOptionUid, DateTime dateTimeOfReservation)
        {
            ServiceOptionUid = serviceOptionUid;
            DateTimeOfReservation = dateTimeOfReservation;
        }

        public Guid ServiceOptionUid { get; }
        public DateTime DateTimeOfReservation { get; }
    }
}
