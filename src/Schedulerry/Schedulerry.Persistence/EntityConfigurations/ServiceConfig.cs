using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerry.Persistence.Entities;

namespace Schedulerry.Persistence.EntityConfigurations
{
    public class ServiceConfig : BaseEntityConfig<Service>
    {
        public ServiceConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            base.Configure(builder);

            builder.ToTable("Service", Schema);

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").IsRequired(false).HasMaxLength(400);
            builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasColumnType("varchar").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.OrganizationFk).HasColumnName("OrganizationFk").HasColumnType("bigint").IsRequired(true);

            builder.HasOne(x => x.Organization).WithMany(x => x.Services).HasForeignKey(x => x.OrganizationFk).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
