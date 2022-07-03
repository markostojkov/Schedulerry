using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Schedulerry.Common.User
{
    public class CurrentUser : ICurrentUser
    {
        private CurrentUser(UserRole role, long id, string email, string username, bool isVerified)
        {
            Role = role;
            Id = id;
            Email = email;
            Username = username;
            IsVerified = isVerified;
        }

        private CurrentUser() : this(UserRole.Guest, 0, string.Empty, string.Empty, false)
        {
        }

        public static ICurrentUser GetCurrentUser(IHttpContextAccessor httpContext)
        {
            var claims = httpContext?.HttpContext?.User?.Claims?.ToList();

            if (claims != null && claims.Any())
            {
                var email = claims.FirstOrDefault(x => x.Type.Equals(UserClaim.EmailAddress))?.Value;
                var username = claims.FirstOrDefault(x => x.Type.Equals(UserClaim.Username))?.Value;

                if (!Enum.TryParse(claims.FirstOrDefault(x => x.Type.Equals(UserClaim.UserType))?.Value, out UserRole roleClaimValue) ||
                    !long.TryParse(claims.FirstOrDefault(x => x.Type.Equals(UserClaim.Id))?.Value, out long idClaimValue) ||
                    string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(username) ||
                    !bool.TryParse(claims.FirstOrDefault(x => x.Type.Equals(UserClaim.IsVerified))?.Value, out bool isVerifiedClaimValue))
                {
                    throw new ArgumentException();
                }

                return new CurrentUser(roleClaimValue, idClaimValue, email, username, isVerifiedClaimValue);
            }

            return new CurrentUser();
        }

        public UserRole Role { get; }

        public long Id { get; }

        public string Email { get; }

        public string Username { get; }

        public bool IsVerified { get; }
    }
}
