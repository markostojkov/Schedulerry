using Microsoft.EntityFrameworkCore;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedulerry.Persistence.Repositories
{
    public class ReservationRepo : IReservationRepo
    {
        public ReservationRepo(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }

        public async Task<List<Reservation>> GetReservationsInIntervalForServiceOption(Guid serviceOptionUid, DateTime start, DateTime end)
        {
            return await DbContext.Reservations.Where(x => x.ServiceOptionUid == serviceOptionUid && start <= x.DateTimeOfReservation && x.DateTimeOfReservation <= end).ToListAsync();
        }
    }
}
