using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Reservations
{
    public class ReserveSessionHandler : ICommandHandler<ReserveSessionCommand, Guid>
    {
        public ReserveSessionHandler(SchedulerryDbContext dbContext, ICurrentUser currentUser)
        {
            DbContext = dbContext;
            CurrentUser = currentUser;
        }

        public SchedulerryDbContext DbContext { get; }
        public ICurrentUser CurrentUser { get; }

        public async Task<Guid> Handle(ReserveSessionCommand request, CancellationToken cancellationToken)
        {
            var customer = await DbContext.Customers.FirstOrDefaultAsync(x => x.ApplicationUserFk == CurrentUser.Id);
            var serviceOption = await DbContext.ServiceOptions.FirstOrDefaultAsync(x => x.Uid == request.ServiceOptionUid);

            var reservation = new Reservation(customer.Id, serviceOption.Uid, serviceOption.Id, request.DateOfReservation, (int)serviceOption.ServiceOptionTimeLength);

            DbContext.Reservations.Add(reservation);

            await DbContext.SaveChangesAsync();

            return reservation.Uid;
        }
    }
}
