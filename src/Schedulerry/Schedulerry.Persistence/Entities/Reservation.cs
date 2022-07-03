using System;

namespace Schedulerry.Persistence.Entities
{
    public class Reservation : BaseEntity
    {
        public Reservation(long customerFk, Guid serviceOptionUid, long serviceOptionFk, DateTime dateTimeOfReservation, int reservationLastsForMinutes) : base()
        {
            CustomerFk = customerFk;
            ServiceOptionUid = serviceOptionUid;
            ServiceOptionFk = serviceOptionFk;
            DateTimeOfReservation = dateTimeOfReservation;
            ReservationLastsForMinutes = reservationLastsForMinutes;
            DateTimeOfReservationEnding = dateTimeOfReservation.AddMinutes(reservationLastsForMinutes);
        }

        public long CustomerFk { get; set; }

        public Customer Customer { get; set; }

        public Guid ServiceOptionUid { get; set; }

        public long ServiceOptionFk { get; set; }

        public ServiceOption ServiceOption { get; set; }

        public DateTime DateTimeOfReservation { get; set; }

        public DateTime DateTimeOfReservationEnding { get; set; }

        public int ReservationLastsForMinutes { get; set; }
    }
}
