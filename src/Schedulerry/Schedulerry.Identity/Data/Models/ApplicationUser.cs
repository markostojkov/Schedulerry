using Microsoft.AspNetCore.Identity;
using Schedulerry.Common.User;

namespace Schedulerry.Identity.Models
{
    public class ApplicationUser : IdentityUser<long>
    {
        public UserRole Role { get; set; }
    }
}
