using System;

namespace Schedulerry.Persistence.Entities
{
    public class Organizer : BaseEntity
    {
        public Organizer(long applicationUserFk, long organizationFk) : base()
        {
            ApplicationUserFk = applicationUserFk;
            OrganizationFk = organizationFk;
            VerificationCode = Guid.NewGuid();
            VerificationCodeExpiration = DateTime.UtcNow;
        }

        public Guid VerificationCode { get; set; }

        public DateTime VerificationCodeExpiration { get; set; }

        public long ApplicationUserFk { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public long OrganizationFk { get; set; }

        public Organization Organization { get; }
    }
}
