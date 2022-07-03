using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerry.Persistence.Entities;

namespace Schedulerry.Persistence.EntityConfigurations
{
    public class CustomerConfig : BaseEntityConfig<Customer>
    {
        public CustomerConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.ToTable("Customer", Schema);

            builder.Property(x => x.ApplicationUserFk).HasColumnName("ApplicationUserFk").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.VerificationCode).HasColumnName("VerificationCode").HasColumnType("uuid").IsRequired();
            builder.Property(x => x.VerificationCodeExpiration).HasColumnName("VerificationCodeExpiration").HasColumnType("timestamp").IsRequired();

            builder.HasOne(x => x.ApplicationUser).WithOne().HasForeignKey<Customer>(x => x.ApplicationUserFk).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
