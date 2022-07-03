using Microsoft.AspNetCore.Authorization;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class ServiceManagedByCurrentOrganizerOrganizationRequirement : IAuthorizationRequirement
    {
        public ServiceManagedByCurrentOrganizerOrganizationRequirement()
        {
        }
    }
}
