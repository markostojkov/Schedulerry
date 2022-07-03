using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerry.Persistence.Entities;

namespace Schedulerry.Persistence.EntityConfigurations
{
    public class OrganizationConfig : BaseEntityConfig<Organization>
    {
        public OrganizationConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Organization> builder)
        {
            base.Configure(builder);

            builder.ToTable("Organization", Schema);

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").IsRequired(false).HasMaxLength(400);
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("varchar").IsRequired(false).HasMaxLength(32);
            builder.Property(x => x.IsVerified).HasColumnName("IsVerified").HasColumnType("boolean").IsRequired(true).HasDefaultValue(false);
        }
    }
}
