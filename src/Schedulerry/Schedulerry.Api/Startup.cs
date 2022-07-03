using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schedulerry.Api.Middleware;
using Schedulerry.Api.Services;
using Schedulerry.Domain.Users.Organizer;
using Schedulerry.Persistence.AppDbContext;

namespace Schedulerry.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public AppSettings AppSettings { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = new AppSettings(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingletonServices();
            services.AddIdentityService(Configuration);
            services.AddMediator();
            services.AddEmailService();
            services.AddOriginUrlSettings();
            services.AddCurrentUser();
            services.AddRepos();
            services.AddAwsClient(Configuration);

            services.AddDbContext<SchedulerryDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = context => new BadRequestObjectResult(context.ModelState))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateOrganizerWithOrganizationValidator>());

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: AppSettings.CorsSettings.CorsPolicyName,
                    builder => builder.WithOrigins(AppSettings.CorsSettings.AllowedCorsOrigins).AllowAnyHeader().AllowAnyMethod());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandler>();

            app.UseRouting();
            app.UseCors(AppSettings.CorsSettings.CorsPolicyName);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
