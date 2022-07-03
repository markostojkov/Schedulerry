using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Persistence.AppDbContext;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class ServiceManagedByCurrentOrganizerOrganizationRequirementHandler : AuthorizationHandler<ServiceManagedByCurrentOrganizerOrganizationRequirement>
    {
        public ServiceManagedByCurrentOrganizerOrganizationRequirementHandler(SchedulerryDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ServiceManagedByCurrentOrganizerOrganizationRequirement requirement)
        {
            if (!Guid.TryParse(HttpContextAccessor.HttpContext.GetRouteData().Values["organizationUid"].ToString(), out Guid organizationUid))
            {
                context.Fail();
                return;
            }

            if (!Guid.TryParse(HttpContextAccessor.HttpContext.GetRouteData().Values["serviceUid"].ToString(), out Guid serviceUid))
            {
                context.Fail();
                return;
            }

            var service = await DbContext.Services.FirstOrDefaultAsync(x => x.Uid == serviceUid && x.Organization.Uid == organizationUid);

            if (service == null)
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
