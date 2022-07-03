using System;

namespace Schedulerry.Persistence.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Uid = Guid.NewGuid();
        }

        public long Id { get; set; }

        public Guid Uid { get; set; }
    }
}
