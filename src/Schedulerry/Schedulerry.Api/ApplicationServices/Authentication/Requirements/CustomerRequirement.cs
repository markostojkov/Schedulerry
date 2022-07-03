using Microsoft.AspNetCore.Authorization;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class CustomerRequirement : IAuthorizationRequirement
    {
        public CustomerRequirement()
        {
        }
    }
}
