using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerry.Persistence.Entities;

namespace Schedulerry.Persistence.EntityConfigurations
{
    public class ServiceOptionConfig : BaseEntityConfig<ServiceOption>
    {
        public ServiceOptionConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<ServiceOption> builder)
        {
            base.Configure(builder);

            builder.ToTable("ServiceOption", Schema);

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").IsRequired(false).HasMaxLength(400);
            builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasColumnType("varchar").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.ServiceFk).HasColumnName("ServiceFk").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Price).HasColumnName("Price").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Currency).HasColumnName("Currency").HasColumnType("varchar").HasMaxLength(3).IsRequired();
            builder.Property(x => x.ServiceOptionTimeLength).HasColumnName("ServiceOptionTimeLength").HasColumnType("smallint").IsRequired();

            builder.HasOne(x => x.Service).WithMany(x => x.ServiceOptions).HasForeignKey(x => x.ServiceFk).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
