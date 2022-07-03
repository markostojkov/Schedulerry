using Schedulerry.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedulerry.Persistence.Repositories
{
    public interface IReservationRepo
    {
        Task<List<Reservation>> GetReservationsInIntervalForServiceOption(Guid serviceOptionUid, DateTime start, DateTime end);
    }
}
