using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Schedulerry.Common.User;
using Schedulerry.Identity.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Schedulerry.Identity.Services
{
    public class SchedulerryProfileService : DefaultProfileService
    {
        public SchedulerryProfileService(UserManager<ApplicationUser> userManager, ILogger<DefaultProfileService> logger) : base(logger)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await UserManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>
            {
                new Claim(UserClaim.Id, user.Id.ToString()),
                new Claim(UserClaim.UserType, user.Role.ToString()),
                new Claim(UserClaim.EmailAddress, user.Email),
                new Claim(UserClaim.Username, user.UserName),
                new Claim(UserClaim.IsVerified, user.EmailConfirmed.ToString())
            };

            context.IssuedClaims.AddRange(claims);
        }

        public override async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await UserManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null) && user.EmailConfirmed;
        }
    }
}
