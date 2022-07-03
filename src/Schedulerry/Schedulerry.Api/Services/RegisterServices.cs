using Amazon.S3;
using Amazon.SimpleEmail;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Schedulerry.Api.ApplicationServices.Authentication;
using Schedulerry.Api.ApplicationServices.Email;
using Schedulerry.Api.ApplicationServices.OriginUrlSettings;
using Schedulerry.Api.ApplicationServices.Storage;
using Schedulerry.Common.Mediator;
using Schedulerry.Common.Mediator.Interfaces;
using Schedulerry.Common.User;
using Schedulerry.Common.Validation;
using Schedulerry.Domain.Users.Organizer;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using Schedulerry.Persistence.Repositories;
using System.Linq;

namespace Schedulerry.Api.Services
{
    public static class RegisterServices
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddScoped<IMediatorService, MediatorService>();
            services.AddScoped<IEventService, EventService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(typeof(CreateOrganizerWithOrganizationHandler));
        }

        public static void AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<AppSettings, AppSettings>();
        }

        public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings(configuration);

            services.AddIdentity<ApplicationUser, ApplicationRole>(o =>
            {
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<SchedulerryDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => 
            {
                o.Authority = appSettings.IdentitySettings.Authority;
                o.Audience = appSettings.IdentitySettings.Audience;
                o.RequireHttpsMetadata = appSettings.IdentitySettings.RequireHttpsMetadata; 
            });

            services.AddScoped<IAuthorizationHandler, OrganizerRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, CustomerRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, OrganizationManagedByCurrentOrganizerRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, ServiceManagedByCurrentOrganizerOrganizationRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganizationRequirementHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthenticationPolicy.Organizer, policy => policy.Requirements.Add(new OrganizerRequirement()));
                options.AddPolicy(AuthenticationPolicy.Customer, policy => policy.Requirements.Add(new CustomerRequirement()));
                options.AddPolicy(AuthenticationPolicy.OrganizationManagedByCurrentOrganizer, policy => policy.Requirements.Add(new OrganizationManagedByCurrentOrganizerRequirement()));
                options.AddPolicy(AuthenticationPolicy.ServiceManagedByCurrentOrganizerOrganization, policy => policy.Requirements.Add(new ServiceManagedByCurrentOrganizerOrganizationRequirement()));
                options.AddPolicy(AuthenticationPolicy.ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganization, policy => policy.Requirements.Add(new ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganizationRequirement()));
            });
        }

        public static void AddEmailService(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }

        public static void AddCurrentUser(this IServiceCollection services)
        {
            services.AddScoped(x =>
            {
                var httpContext = x.GetRequiredService<IHttpContextAccessor>();
                return CurrentUser.GetCurrentUser(httpContext);
            });
        }
        
        public static void AddRepos(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationRepo, OrganizationRepo>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IReservationRepo, ReservationRepo>();
        }

        public static void AddOriginUrlSettings(this IServiceCollection services)
        {
            services.AddScoped<IOriginUrlSettings>(provider =>
            {
                var httpContextAccessor = provider.GetService<IHttpContextAccessor>();

                string originUrl = string.Empty;
                if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Origin", out StringValues headerValues))
                {
                    if (headerValues.FirstOrDefault() != null)
                    {
                        originUrl = headerValues.FirstOrDefault();
                    }
                }

                return new OriginUrlSettings(originUrl);
            });
        }

        public static void AddAwsClient(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings(configuration);

            services.AddAWSService<IAmazonS3>();
            services.AddSingleton<IAmazonS3>(provider =>
            {
                return new AmazonS3Client(
                    appSettings.AwsStorageSettings.AccessKey,
                    appSettings.AwsStorageSettings.SecretKey,
                    Amazon.RegionEndpoint.GetBySystemName(appSettings.AwsStorageSettings.StorageServerRegion));
            });
            services.AddScoped<IStorageService, AwsStorageService>();
        }
    }
}
