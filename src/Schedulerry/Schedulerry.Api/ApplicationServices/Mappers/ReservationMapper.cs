using Schedulerry.Contracts.Reservations.Query;
using Schedulerry.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Schedulerry.Api.ApplicationServices.Mappers
{
    public static class ReservationMapper
    {
        public static IEnumerable<ReservationForServiceOptionResponse> ToReservationForServiceOptionResponses(this List<Reservation> reservations)
        {
            return reservations.Select(x =>
                new ReservationForServiceOptionResponse(x.ServiceOptionUid, x.DateTimeOfReservation, x.DateTimeOfReservationEnding, x.ReservationLastsForMinutes));
        }
    }
}
