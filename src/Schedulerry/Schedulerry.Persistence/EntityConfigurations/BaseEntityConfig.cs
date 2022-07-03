using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerry.Persistence.Entities;

namespace Schedulerry.Persistence.EntityConfigurations
{
    public abstract class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        protected BaseEntityConfig(string schema)
        {
            Schema = schema;
        }

        protected string Schema { get; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uuid").IsRequired();
        }
    }
}
