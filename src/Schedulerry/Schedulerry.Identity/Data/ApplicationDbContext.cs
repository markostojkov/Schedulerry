using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schedulerry.Identity.Models;

namespace Schedulerry.Identity.Data
{
    public class ApplicationDbContext<TUser> : IdentityDbContext<TUser, ApplicationRole, long> where TUser : ApplicationUser
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext<TUser>> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
