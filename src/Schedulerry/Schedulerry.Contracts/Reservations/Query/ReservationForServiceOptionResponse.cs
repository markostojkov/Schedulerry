using System;

namespace Schedulerry.Contracts.Reservations.Query
{
    public class ReservationForServiceOptionResponse
    {
        public ReservationForServiceOptionResponse(Guid reservationUid, DateTime dateTimeOfReservation, DateTime dateTimeOfReservationEnding, int reservationLastsForMinutes)
        {
            ReservationUid = reservationUid;
            DateTimeOfReservation = dateTimeOfReservation;
            DateTimeOfReservationEnding = dateTimeOfReservationEnding;
            ReservationLastsForMinutes = reservationLastsForMinutes;
        }

        public Guid ReservationUid { get; }
        public DateTime DateTimeOfReservation { get; }
        public DateTime DateTimeOfReservationEnding { get; }
        public int ReservationLastsForMinutes { get; }
    }
}
