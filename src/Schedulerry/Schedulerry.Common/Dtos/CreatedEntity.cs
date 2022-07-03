using System;

namespace Schedulerry.Common.Dtos
{
    public class CreatedEntity
    {
        public CreatedEntity(long id, Guid uid)
        {
            Id = id;
            Uid = uid;
        }

        public CreatedEntity(long id, Guid uid, Guid verificationCode)
        {
            Id = id;
            Uid = uid;
            VerificationCode = verificationCode;
        }

        public CreatedEntity(long id)
        {
            Id = id;
        }

        public long Id { get; }
        public Guid Uid { get; }
        public Guid VerificationCode { get; }
    }
}
