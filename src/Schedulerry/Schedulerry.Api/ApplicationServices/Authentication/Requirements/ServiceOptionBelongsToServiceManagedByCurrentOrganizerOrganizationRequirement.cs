using Microsoft.AspNetCore.Authorization;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganizationRequirement : IAuthorizationRequirement
    {
        public ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganizationRequirement()
        {
        }
    }
}
