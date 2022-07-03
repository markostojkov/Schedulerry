using Schedulerry.Common.DateAndTime;
using Schedulerry.Contracts.FieldValidators;
using System;

namespace Schedulerry.Contracts.OrganizationManagement
{
    public class CreateServiceOptionWorkingTimeRequest
    {
        [RequiredValidator]
        public DaysOfWeekEnum DayOfWeek { get; set; }

        [RequiredValidator]
        public DateTime TimeOpen { get; set; }

        [WorkingTimeValidator]
        public int WorkingTimeMinutes { get; set; }
    }
}
