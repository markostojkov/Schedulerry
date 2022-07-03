using Microsoft.AspNetCore.Authorization;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class OrganizerRequirement : IAuthorizationRequirement
    {
        public OrganizerRequirement()
        {
        }
    }
}
