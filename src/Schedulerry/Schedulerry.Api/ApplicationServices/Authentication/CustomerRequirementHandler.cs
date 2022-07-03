using Microsoft.AspNetCore.Authorization;
using Schedulerry.Common.User;
using System.Threading.Tasks;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class CustomerRequirementHandler : AuthorizationHandler<CustomerRequirement>
    {
        public CustomerRequirementHandler(ICurrentUser currentUser)
        {
            CurrentUser = currentUser;
        }

        public ICurrentUser CurrentUser { get; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerRequirement requirement)
        {
            if (CurrentUser.Role != UserRole.Customer)
            {
                context.Fail();
            }

            context.Succeed(requirement);
            return Task.FromResult(0);
        }
    }
}
