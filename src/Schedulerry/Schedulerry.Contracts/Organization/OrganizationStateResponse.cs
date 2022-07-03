using Schedulerry.Common.DateAndTime;
using System;
using System.Collections.Generic;

namespace Schedulerry.Contracts.Organization
{
    public class OrganizationStateResponse
    {
        public OrganizationStateResponse(
            Guid organizationUid,
            string name,
            string description,
            string phoneNumber,
            IEnumerable<ServiceStateResponse> services,
            IEnumerable<OrganizerStateResponse> organizers)
        {
            OrganizationUid = organizationUid;
            Name = name;
            Description = description;
            PhoneNumber = phoneNumber;
            Services = services;
            Organizers = organizers;
        }

        public Guid OrganizationUid { get; }
        public string Name { get; }
        public string Description { get; }
        public string PhoneNumber { get; }
        public IEnumerable<ServiceStateResponse> Services { get; }
        public IEnumerable<OrganizerStateResponse> Organizers { get; }
    }

    public class ServiceStateResponse
    {
        public ServiceStateResponse(Guid uid, string name, string description, string imageUrl, IEnumerable<ServiceOptionStateResponse> serviceOptions)
        {
            Uid = uid;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            ServiceOptions = serviceOptions;
        }

        public Guid Uid { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public IEnumerable<ServiceOptionStateResponse> ServiceOptions { get; }
    }

    public class ServiceOptionStateResponse
    {
        public ServiceOptionStateResponse(Guid uid, string name, string description, string imageUrl, decimal price, string currency, TimeLengthMinutesOptionsEnum serviceOptionTimeLength, IEnumerable<ServiceOptionScheduleStateResponse> serviceOptionSchedules)
        {
            Uid = uid;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            Currency = currency;
            ServiceOptionTimeLength = serviceOptionTimeLength;
            ServiceOptionSchedules = serviceOptionSchedules;
        }

        public Guid Uid { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public decimal Price { get; }
        public string Currency { get; }
        public TimeLengthMinutesOptionsEnum ServiceOptionTimeLength { get; }
        public IEnumerable<ServiceOptionScheduleStateResponse> ServiceOptionSchedules { get; }
    }

    public class ServiceOptionScheduleStateResponse
    {
        public ServiceOptionScheduleStateResponse(Guid uid, DaysOfWeekEnum dayOfWeek, DateTime timeOpen, int workingTimeMinutes)
        {
            Uid = uid;
            DayOfWeek = dayOfWeek;
            TimeOpen = timeOpen;
            WorkingTimeMinutes = workingTimeMinutes;
        }

        public Guid Uid { get; }
        public DaysOfWeekEnum DayOfWeek { get; }
        public DateTime TimeOpen { get; }
        public int WorkingTimeMinutes { get; }
    }

    public class OrganizerStateResponse
    {
        public OrganizerStateResponse(Guid uid, string username, string email, bool emailConfirmed)
        {
            Uid = uid;
            Username = username;
            Email = email;
            EmailConfirmed = emailConfirmed;
        }

        public Guid Uid { get; }
        public string Username { get; }
        public string Email { get; }
        public bool EmailConfirmed { get; }
    }
}
