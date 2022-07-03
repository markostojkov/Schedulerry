using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Persistence.AppDbContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceOptionWorkingTimeHandler : ICommandHandler<CreateServiceOptionWorkingTimeCommand, IEnumerable<CreateServiceOptionWorkingTimeDto>>
    {
        public CreateServiceOptionWorkingTimeHandler(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }

        public async Task<IEnumerable<CreateServiceOptionWorkingTimeDto>> Handle(CreateServiceOptionWorkingTimeCommand request, CancellationToken cancellationToken)
        {
            var serviceOptionSchedule = await DbContext.ServiceOptionSchedule
                .Where(x => x.ServiceOption.Uid == request.ServiceOptionUid)
                .ToListAsync();

            foreach (var day in serviceOptionSchedule)
            {
                var requestDay = request.ServiceOptionWorkingTimes.FirstOrDefault(x => x.DayOfWeek == day.DayOfWeek);

                day.TimeOpen = requestDay.TimeOpen;
                day.WorkingTimeMinutes = requestDay.WorkingTimeMinutes;
            }

            await DbContext.SaveChangesAsync();

            return serviceOptionSchedule.Select(x =>
                new CreateServiceOptionWorkingTimeDto(x.Uid, x.ServiceOption.Uid, x.DayOfWeek, x.TimeOpen, x.WorkingTimeMinutes)).OrderBy(x => x.DayOfWeek);
        }
    }
}
