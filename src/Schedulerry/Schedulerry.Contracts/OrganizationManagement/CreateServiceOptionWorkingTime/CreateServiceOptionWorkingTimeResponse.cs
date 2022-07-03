using Schedulerry.Common.DateAndTime;
using System;

namespace Schedulerry.Contracts.OrganizationManagement
{
    public class CreateServiceOptionWorkingTimeResponse
    {
        public CreateServiceOptionWorkingTimeResponse(Guid uid, Guid serviceOptionUid, DaysOfWeekEnum dayOfWeek, DateTime timeOpen, int workingTimeMinutes)
        {
            Uid = uid;
            ServiceOptionUid = serviceOptionUid;
            DayOfWeek = dayOfWeek;
            TimeOpen = timeOpen;
            WorkingTimeMinutes = workingTimeMinutes;
        }

        public Guid Uid { get; }
        public Guid ServiceOptionUid { get; }
        public DaysOfWeekEnum DayOfWeek { get; }
        public DateTime TimeOpen { get; }
        public int WorkingTimeMinutes { get; }
    }
}
