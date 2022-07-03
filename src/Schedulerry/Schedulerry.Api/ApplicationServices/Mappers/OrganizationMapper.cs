using Schedulerry.Contracts.Organization;
using Schedulerry.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Schedulerry.Api.ApplicationServices.Mappers
{
    public static class OrganizationMapper
    {
        public static OrganizationStateResponse ToOrganizationStateResponse(this Organization organization)
        {
            return new OrganizationStateResponse(organization.Uid, organization.Name, organization.Description, organization.PhoneNumber, organization.Services.ToServicesStateResponse(), organization.Organizers.ToOrganizersStateResponse());
        }

        public static IEnumerable<ServiceStateResponse> ToServicesStateResponse(this List<Service> services)
        {
            if (services.Any())
            {
                return services.Select(x => new ServiceStateResponse(x.Uid, x.Name, x.Description, x.ImageUrl, x.ServiceOptions.ToServiceOptionsStateResponse()));
            }

            return Enumerable.Empty<ServiceStateResponse>();
        }

        public static IEnumerable<ServiceOptionStateResponse> ToServiceOptionsStateResponse(this List<ServiceOption> serviceOptions)
        {
            if (serviceOptions.Any())
            {
                return serviceOptions.Select(x => new ServiceOptionStateResponse(x.Uid, x.Name, x.Description, x.ImageUrl, x.Price, x.Currency, x.ServiceOptionTimeLength, x.ServiceOptionSchedules.ToServicesOptionSchedulesStateResponse()));
            }

            return Enumerable.Empty<ServiceOptionStateResponse>();
        }

        public static IEnumerable<ServiceOptionScheduleStateResponse> ToServicesOptionSchedulesStateResponse(this List<ServiceOptionSchedule> schedules)
        {
            if (schedules.Any())
            {
                return schedules.Select(x => new ServiceOptionScheduleStateResponse(x.Uid, x.DayOfWeek, x.TimeOpen, x.WorkingTimeMinutes));
            }

            return Enumerable.Empty<ServiceOptionScheduleStateResponse>();
        }

        public static IEnumerable<OrganizerStateResponse> ToOrganizersStateResponse(this List<Organizer> organizers)
        {
            if (organizers.Any())
            {
                return organizers.Select(x => new OrganizerStateResponse(x.Uid, x.ApplicationUser.UserName, x.ApplicationUser.Email, x.ApplicationUser.EmailConfirmed));
            }

            return Enumerable.Empty<OrganizerStateResponse>();
        }
    }
}
