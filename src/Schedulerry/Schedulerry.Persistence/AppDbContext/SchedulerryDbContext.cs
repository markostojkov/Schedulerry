using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Persistence.Entities;
using Schedulerry.Persistence.EntityConfigurations;

namespace Schedulerry.Persistence.AppDbContext
{
    public class SchedulerryDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public SchedulerryDbContext(DbContextOptions<SchedulerryDbContext> options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceOption> ServiceOptions { get; set; }

        public DbSet<ServiceOptionSchedule> ServiceOptionSchedule { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            const string schema = "dbo";

            modelBuilder.ApplyConfiguration(new OrganizationConfig(schema));
            modelBuilder.ApplyConfiguration(new OrganizerConfig(schema));
            modelBuilder.ApplyConfiguration(new ServiceConfig(schema));
            modelBuilder.ApplyConfiguration(new ServiceOptionConfig(schema));
            modelBuilder.ApplyConfiguration(new ServiceOptionScheduleConfig(schema));
            modelBuilder.ApplyConfiguration(new CustomerConfig(schema));
            modelBuilder.ApplyConfiguration(new ReservationConfig(schema));

            /*modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id = 1,
                    Uid = System.Guid.NewGuid(),
                    Name = "TEST",
                }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    Role = Common.User.UserRole.Organizer,
                    UserName = "organizer",
                    NormalizedUserName = "organizer",
                    Email = "organizer@test.com",
                    NormalizedEmail = "organizer@test.com",
                    EmailConfirmed = true
                }
            );

            modelBuilder.Entity<Organizer>().HasData(
                new Organizer
                {
                    Id = 1,
                    Uid = System.Guid.NewGuid(),
                    Name = "TEST",
                }
            );

            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id = 1,
                    Uid = System.Guid.NewGuid(),
                    Name = "TEST",
                }
            );*/
        }
    }
}
