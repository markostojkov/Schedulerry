using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerry.Persistence.Entities;

namespace Schedulerry.Persistence.EntityConfigurations
{
    public class ReservationConfig : BaseEntityConfig<Reservation>
    {
        public ReservationConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);

            builder.ToTable("Reservation", Schema);

            builder.Property(x => x.CustomerFk).HasColumnName("CustomerFk").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.ServiceOptionUid).HasColumnName("ServiceOptionUid").HasColumnType("uuid").IsRequired();
            builder.Property(x => x.ServiceOptionFk).HasColumnName("ServiceOptionFk").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.DateTimeOfReservation).HasColumnName("DateTimeOfReservation").HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.DateTimeOfReservationEnding).HasColumnName("DateTimeOfReservationEnding").HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.ReservationLastsForMinutes).HasColumnName("ReservationLastsForMinutes").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.Reservations).HasForeignKey(x => x.CustomerFk).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ServiceOption).WithMany(x => x.Reservations).HasForeignKey(x => x.ServiceOptionFk).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
