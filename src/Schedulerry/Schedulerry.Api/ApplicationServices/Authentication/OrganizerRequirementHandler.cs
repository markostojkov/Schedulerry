using Microsoft.AspNetCore.Authorization;
using Schedulerry.Common.User;
using System.Threading.Tasks;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class OrganizerRequirementHandler : AuthorizationHandler<OrganizerRequirement>
    {
        public OrganizerRequirementHandler(ICurrentUser currentUser)
        {
            CurrentUser = currentUser;
        }

        public ICurrentUser CurrentUser { get; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OrganizerRequirement requirement)
        {
            if (CurrentUser.Role != UserRole.Organizer)
            {
                context.Fail();
            }

            context.Succeed(requirement);
            return Task.FromResult(0);
        }
    }
}
