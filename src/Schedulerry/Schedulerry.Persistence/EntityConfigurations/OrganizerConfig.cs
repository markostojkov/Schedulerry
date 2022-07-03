using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerry.Persistence.Entities;

namespace Schedulerry.Persistence.EntityConfigurations
{
    public class OrganizerConfig : BaseEntityConfig<Organizer>
    {
        public OrganizerConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Organizer> builder)
        {
            base.Configure(builder);

            builder.ToTable("Organizer", Schema);

            builder.Property(x => x.OrganizationFk).HasColumnName("OrganizationFk").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.ApplicationUserFk).HasColumnName("ApplicationUserFk").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.VerificationCode).HasColumnName("VerificationCode").HasColumnType("uuid").IsRequired();
            builder.Property(x => x.VerificationCodeExpiration).HasColumnName("VerificationCodeExpiration").HasColumnType("timestamp").IsRequired();

            builder.HasOne(x => x.Organization).WithMany(x => x.Organizers).HasForeignKey(x => x.OrganizationFk).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ApplicationUser).WithOne(x => x.Organizer).HasForeignKey<Organizer>(x => x.ApplicationUserFk).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
