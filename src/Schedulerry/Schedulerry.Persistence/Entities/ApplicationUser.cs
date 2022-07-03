using Microsoft.AspNetCore.Identity;
using Schedulerry.Common.User;

namespace Schedulerry.Persistence.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public UserRole Role { get; set; }

        public Organizer Organizer { get; set; }
    }
}
