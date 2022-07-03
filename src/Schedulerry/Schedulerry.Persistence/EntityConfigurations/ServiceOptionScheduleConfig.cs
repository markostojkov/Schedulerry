using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerry.Persistence.Entities;

namespace Schedulerry.Persistence.EntityConfigurations
{
    public class ServiceOptionScheduleConfig : BaseEntityConfig<ServiceOptionSchedule>
    {
        public ServiceOptionScheduleConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<ServiceOptionSchedule> builder)
        {
            base.Configure(builder);

            builder.ToTable("ServiceOptionSchedule", Schema);

            builder.Property(x => x.DayOfWeek).HasColumnName("DayOfWeek").HasColumnType("smallint").IsRequired();
            builder.Property(x => x.TimeOpen).HasColumnName("TimeOpen").HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.WorkingTimeMinutes).HasColumnName("WorkingTimeMinutes").HasColumnType("integer").IsRequired();
            builder.Property(x => x.ServiceOptionFk).HasColumnName("ServiceOptionFk").HasColumnType("bigint").IsRequired();

            builder.HasOne(x => x.ServiceOption).WithMany(x => x.ServiceOptionSchedules).HasForeignKey(x => x.ServiceOptionFk).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
