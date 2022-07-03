using System;

namespace Schedulerry.Persistence.Contracts
{
    public class SelfUserDto
    {
        public SelfUserDto(Guid uid, Guid? organizationUid)
        {
            Uid = uid;
            OrganizationUid = organizationUid;
        }

        public Guid Uid { get; }
        public Guid? OrganizationUid { get; }
    }
}
