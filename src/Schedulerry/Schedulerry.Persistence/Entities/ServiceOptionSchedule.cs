using Schedulerry.Common.DateAndTime;
using System;

namespace Schedulerry.Persistence.Entities
{
    public class ServiceOptionSchedule : BaseEntity
    {
        public ServiceOptionSchedule(DaysOfWeekEnum dayOfWeek, DateTime timeOpen, int workingTimeMinutes) : base()
        {
            DayOfWeek = dayOfWeek;
            TimeOpen = timeOpen;
            WorkingTimeMinutes = workingTimeMinutes;
        }

        public DaysOfWeekEnum DayOfWeek { get; set; }

        public DateTime TimeOpen { get; set; }

        public int WorkingTimeMinutes { get; set; }

        public long ServiceOptionFk { get; set; }

        public virtual ServiceOption ServiceOption { get; set; }
    }
}
