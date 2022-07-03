using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class OrganizationManagedByCurrentOrganizerRequirementHandler : AuthorizationHandler<OrganizationManagedByCurrentOrganizerRequirement>
    {
        public OrganizationManagedByCurrentOrganizerRequirementHandler(SchedulerryDbContext dbContext, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
        {
            DbContext = dbContext;
            CurrentUser = currentUser;
            HttpContextAccessor = httpContextAccessor;
        }

        public SchedulerryDbContext DbContext { get; }

        public ICurrentUser CurrentUser { get; }

        public IHttpContextAccessor HttpContextAccessor { get; }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OrganizationManagedByCurrentOrganizerRequirement requirement)
        {
            if (!Guid.TryParse(HttpContextAccessor.HttpContext.GetRouteData().Values["organizationUid"].ToString(), out Guid organizationUid))
            {
                context.Fail();
                return;
            }

            var organization = await DbContext.Organizers.FirstOrDefaultAsync(x => x.Organization.Uid == organizationUid && x.ApplicationUserFk == CurrentUser.Id);

            if (organization == null)
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
