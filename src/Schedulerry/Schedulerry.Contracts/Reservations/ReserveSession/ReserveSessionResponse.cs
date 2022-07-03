using System;

namespace Schedulerry.Contracts.Reservations
{
    public class ReserveSessionResponse
    {
        public ReserveSessionResponse(Guid reservationUid)
        {
            ReservationUid = reservationUid;
        }

        public Guid ReservationUid { get; }
    }
}
