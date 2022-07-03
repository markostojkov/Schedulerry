using Microsoft.AspNetCore.Authorization;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class OrganizationManagedByCurrentOrganizerRequirement : IAuthorizationRequirement
    {
        public OrganizationManagedByCurrentOrganizerRequirement()
        {
        }
    }
}
