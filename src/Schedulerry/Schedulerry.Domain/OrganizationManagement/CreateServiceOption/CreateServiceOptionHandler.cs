using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.DateAndTime;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceOptionHandler : ICommandHandler<CreateServiceOptionCommand, CreateServiceOptionDto>
    {
        public CreateServiceOptionHandler(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }

        public async Task<CreateServiceOptionDto> Handle(CreateServiceOptionCommand request, CancellationToken cancellationToken)
        {
            var service = await DbContext.Services.FirstOrDefaultAsync(x => x.Uid == request.ServiceUid);

            var serviceOption = new ServiceOption(
                request.Name,
                request.Description,
                request.LogoUrl,
                request.Price,
                request.Currency,
                request.ServiceOptionTimeLength,
                DayOfWeekList.DaysOfWeeks.Select(x => new ServiceOptionSchedule(x, new DateTime(2014, 06, 21, 0, 0, 0), 0)).ToList());

            service.ServiceOptions.Add(serviceOption);
            await DbContext.SaveChangesAsync();

            return new CreateServiceOptionDto(
                serviceOption.Uid,
                service.Uid,
                serviceOption.Name,
                serviceOption.Description,
                serviceOption.ImageUrl,
                serviceOption.Price,
                serviceOption.Currency,
                serviceOption.ServiceOptionTimeLength,
                serviceOption.ServiceOptionSchedules.Select(x =>
                new CreateServiceOptionWorkingTimeDto(x.Uid, x.ServiceOption.Uid, x.DayOfWeek, x.TimeOpen, x.WorkingTimeMinutes)).OrderBy(x => x.DayOfWeek));
        }
    }
}
