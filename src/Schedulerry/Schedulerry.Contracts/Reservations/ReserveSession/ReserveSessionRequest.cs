using Schedulerry.Contracts.FieldValidators;
using System;

namespace Schedulerry.Contracts.Reservations
{
    public class ReserveSessionRequest
    {
        [ReservationDateTimeValidator]
        public DateTime Date { get; set; }
    }
}
