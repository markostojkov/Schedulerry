using Schedulerry.Common.DateAndTime;
using Schedulerry.Common.Mediator.Contracs;
using System;
using System.Collections.Generic;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceOptionWorkingTimeCommand : ICommand<IEnumerable<CreateServiceOptionWorkingTimeDto>>
    {
        public CreateServiceOptionWorkingTimeCommand(Guid serviceOptionUid, IEnumerable<CreateServiceOptionWorkingTimeCommandDto> serviceOptionWorkingTimes)
        {
            ServiceOptionUid = serviceOptionUid;
            ServiceOptionWorkingTimes = serviceOptionWorkingTimes;
        }

        public Guid ServiceOptionUid { get; }
        public IEnumerable<CreateServiceOptionWorkingTimeCommandDto> ServiceOptionWorkingTimes { get; }
    }

    public class CreateServiceOptionWorkingTimeCommandDto
    {
        public CreateServiceOptionWorkingTimeCommandDto(DaysOfWeekEnum dayOfWeek, DateTime timeOpen, int workingTimeMinutes)
        {
            DayOfWeek = dayOfWeek;
            TimeOpen = timeOpen;
            WorkingTimeMinutes = workingTimeMinutes;
        }

        public DaysOfWeekEnum DayOfWeek { get; }
        public DateTime TimeOpen { get; }
        public int WorkingTimeMinutes { get; }
    }
}
