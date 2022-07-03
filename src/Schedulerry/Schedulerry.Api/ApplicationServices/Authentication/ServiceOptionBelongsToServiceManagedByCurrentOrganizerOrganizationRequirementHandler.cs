using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Persistence.AppDbContext;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public class ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganizationRequirementHandler
        : AuthorizationHandler<ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganizationRequirement>
    {
        public ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganizationRequirementHandler(
            SchedulerryDbContext dbContext,
            IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
            DbContext = dbContext;
        }

        public IHttpContextAccessor HttpContextAccessor { get; }
        public SchedulerryDbContext DbContext { get; }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganizationRequirement requirement)
        {
            if (!Guid.TryParse(HttpContextAccessor.HttpContext.GetRouteData().Values["serviceUid"].ToString(), out Guid serviceUid))
            {
                context.Fail();
                return;
            }

            if (!Guid.TryParse(HttpContextAccessor.HttpContext.GetRouteData().Values["serviceOptionUid"].ToString(), out Guid serviceOptionUid))
            {
                context.Fail();
                return;
            }

            var service = await DbContext.ServiceOptions.FirstOrDefaultAsync(x => x.Uid == serviceOptionUid && x.Service.Uid == serviceUid);

            if (service == null)
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
