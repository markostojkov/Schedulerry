using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Schedulerry.Identity.Data;
using Schedulerry.Identity.Models;

namespace Schedulerry.Identity.Services
{
    public static class RegisterServices
    {
        public static void AddIdentityServerAndIdentityProvider(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext<ApplicationUser>>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                options.EmitStaticAudienceClaim = true;
            })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.ApiResources(appSettings))
                .AddInMemoryApiScopes(Config.ApiScopes(appSettings))
                .AddInMemoryClients(Config.Clients(appSettings))
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<SchedulerryProfileService>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication();
        }

        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddSingleton<AppSettings, AppSettings>();
        }
    }
}
