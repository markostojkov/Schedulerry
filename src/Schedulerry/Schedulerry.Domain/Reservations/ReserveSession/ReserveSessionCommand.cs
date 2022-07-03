using Schedulerry.Common.Mediator.Contracs;
using System;

namespace Schedulerry.Domain.Reservations
{
    public class ReserveSessionCommand : ICommand<Guid>
    {
        public ReserveSessionCommand(DateTime dateOfReservation, Guid serviceOptionUid)
        {
            DateOfReservation = dateOfReservation;
            ServiceOptionUid = serviceOptionUid;
        }

        public DateTime DateOfReservation { get; }
        public Guid ServiceOptionUid { get; }
    }
}
