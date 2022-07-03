using System;
using System.Collections.Generic;

namespace Schedulerry.Persistence.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(long applicationUserFk) : base()
        {
            ApplicationUserFk = applicationUserFk;
            VerificationCode = Guid.NewGuid();
            VerificationCodeExpiration = DateTime.UtcNow;
        }

        public Guid VerificationCode { get; set; }

        public DateTime VerificationCodeExpiration { get; set; }

        public long ApplicationUserFk { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
    }
}
